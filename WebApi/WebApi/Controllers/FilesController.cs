using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public FilesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        [HttpGet("UserFilesByUser/{userId}")]
        public async Task<IActionResult> GetUserFilesById(string userId)
        {
            // Kontrollera att användaren är antingen admin eller den begärande användaren
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");

            if (currentUserId != userId && !isAdmin)
            {
                return Forbid(); // Om användaren inte är admin eller den begärande användaren
            }

            var userFiles = await context.Files.Where(f => f.ApplicationUserId == userId).ToListAsync();

            if (userFiles == null || userFiles.Count == 0)
            {
                return NotFound("No files found for this user.");
            }

            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var fileModels = userFiles.Select(file => new
            {
                name = file.Name,
                type = file.Type,
                url = $"{baseUrl}{file.Path}"  // Generera URL för nedladdning
            });

            return Ok(fileModels);
        }

    }
}
