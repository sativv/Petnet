using WebApi.Data;

namespace WebApi.Models
{
    public class BookmarkModel
    {

        public ApplicationUser User { get; set; } = null!;
        public string ApplicationUserId { get; set; }


        public PostModel PostModel { get; set; } = null!;
        public int PostModelId { get; set; }

    }
}
