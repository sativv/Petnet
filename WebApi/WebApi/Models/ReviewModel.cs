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

        // User who wrote the review
        public string ReviewerId { get; set; } // Use string to match ApplicationUser's primary key type
        public ApplicationUser? Reviewer { get; set; }

        // User who is being reviewed
        public string ReviewedSellerId { get; set; } // Use string to match ApplicationUser's primary key type
        public ApplicationUser? ReviewedSeller { get; set; }



    }
}
