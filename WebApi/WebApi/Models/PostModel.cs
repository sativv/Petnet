using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using WebApi.Data;

namespace WebApi.Models
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<string> Images { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateOnly? DateOfBirth { get; set; }

        public string AnimalType { get; set; } = null!;
        public string AnimalBreed { get; set; } = null!;
        public int Age { get; set; }
        public bool IsAdoptionReady { get; set; }
        public DateOnly? EarliestDelivery { get; set; }
        public List<InterestModel> Interests { get; set; } = new List<InterestModel>();
        // Varje post har en user som har postat den 
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public string ApplicationUserId { get; set; } // Use string to match ApplicationUser's primary key type
    }
}
