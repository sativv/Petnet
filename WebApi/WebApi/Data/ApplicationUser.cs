using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<PostModel> Posts { get; set; } = new List<PostModel>();
    }
}
