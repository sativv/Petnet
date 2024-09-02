using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? QuizResult { get; set; }
        public bool IsPrivateSeller { get; set; }
        public bool IsVerified { get; set; }
        public int OrganizationNumber { get; set; }
        public string? AboutMe { get; set; }
        public int OrganizationName { get; set; }
        public string? BuisnessContact { get; set; }
        public string? Adress { get; set; }
        public int Postcode { get; set; }
        public List<FileModel> MyFiles { get; set; } = new List<FileModel>();
        public List<PostModel> Posts { get; set; } = new List<PostModel>();
        public List<InterestModel> Interests { get; set; } = new List<InterestModel>();
        public List<ReviewModel> ReviewsWritten { get; set; } = new List<ReviewModel>();
        public List<ReviewModel> ReviewsRecieved { get; set; } = new List<ReviewModel>();


    }
}
