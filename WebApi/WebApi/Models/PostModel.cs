using System.ComponentModel.DataAnnotations;
using WebApi.Data;

namespace WebApi.Models
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public string AnimalType { get; set; }
        public string AnimalBreed { get; set; }
        public int Age { get; set; }
        public bool IsAdoptionReady { get; set; }
        public DateOnly? EarliestDelivery { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
