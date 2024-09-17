using System.Security.Claims;
using WebApi.Data;

namespace WebApi.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FileAccessMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;

        public FileAccessMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestPath = context.Request.Path.Value;
            // Om det inte är en begäran om en fil i FileUploads, fortsätt
            if (requestPath.StartsWith("/FileUploads") && context.Request.Query.ContainsKey("token"))
            {
                var token = context.Request.Query["token"].ToString();
                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        var decodedToken = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(token));
                        Console.WriteLine($"Decoded Token: {decodedToken}");
                        var parts = decodedToken.Split(':');
                        if (parts.Length != 2)
                        {
                            Console.WriteLine("Token format invalid.");
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return;
                        }

                        var fileId = parts[0];
                        var userId = parts[1];

                        Console.WriteLine($"Decoded Token - FileId: {fileId}, UserId: {userId}");

                        var currentUserId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

                        if (currentUserId != userId)
                        {
                            Console.WriteLine($"User with ID {userId} not found.");
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return;
                        }

                        // Använd en ny scope för att skapa en databaskontext
                        using (var scope = _scopeFactory.CreateScope())
                        {
                            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                            var file = await dbContext.Files.FindAsync(int.Parse(fileId));

                            if (file == null)
                            {
                                Console.WriteLine($"File with ID {fileId} not found.");
                                context.Response.StatusCode = StatusCodes.Status404NotFound;
                                return;
                            }

                            // Check if the user has access to the file
                            if (file.ApplicationUserId != currentUserId && !context.User.IsInRole("Admin"))
                            {
                                Console.WriteLine("Access denied for the file.");
                                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                                return;
                            }

                            // Filvägen baserat på den privata mappen
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FileUploads", Path.GetFileName(requestPath));

                            if (!System.IO.File.Exists(filePath))
                            {
                                context.Response.StatusCode = StatusCodes.Status404NotFound;
                                return;
                            }

                            context.Response.ContentType = "application/octet-stream";
                            await context.Response.SendFileAsync(filePath);
                            return;
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Token decoding failed: {ex.Message}");
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return;
                    }

                }

                Console.WriteLine("Token is missing.");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }


            await _next(context);
        }

    }
    public static class FileAccessMiddlewareExtensions
    {
        public static IApplicationBuilder UseFileAccessMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FileAccessMiddleware>();
        }
    }
}
