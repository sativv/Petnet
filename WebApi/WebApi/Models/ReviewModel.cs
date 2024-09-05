using System.ComponentModel.DataAnnotations;
using WebApi.Data;

namespace WebApi.Models
{
    public class ReviewModel
    {
        [Key]
        public int ReviewId { get; set; }
        public string Content { get; set; } = null!;
        public int Rating { get; set; }
        public string ReviewerId { get; set; }
        public ApplicationUser? Reviewer { get; set; }
        public string ReviewedSellerId { get; set; }
        public ApplicationUser? ReviewedSeller { get; set; }



    }
}
