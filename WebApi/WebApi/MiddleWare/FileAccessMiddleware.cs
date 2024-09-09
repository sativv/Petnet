using Microsoft.EntityFrameworkCore;
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
            // Om det inte är en begäran om en fil i FileUploads, fortsätt
            if (!context.Request.Path.StartsWithSegments("/FileUploads"))
            {
                await _next(context);
                return;
            }

            // Kontrollera att användaren är autentiserad
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var currentUserId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Använd en ny scope för att skapa en databaskontext
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Hämta filmetadata från databasen
                var files = await dbContext.Files
                    .Where(f => f.ApplicationUserId == currentUserId).ToListAsync();

                if (files == null || files.Count < 1)
                {
                    // Kontrollera om användaren är administratör
                    var isAdmin = context.User.IsInRole("Admin");
                    if (files[0].ApplicationUserId != currentUserId && !isAdmin)
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return;
                    }
                }
            }
            // Om alla kontroller är godkända, fortsätt till nästa middleware
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
