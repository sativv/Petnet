using WebApi.Data;

namespace WebApi.Models
{
    public class InterestModel
    {
        // En user har ett interest 
        public ApplicationUser User { get; set; } = null!;
        public string ApplicationUserId { get; set; }

        // Userns interest är på en post
        public PostModel PostModel { get; set; } = null!;
        public int PostId { get; set; }




    }
}
