using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class OptionModel
    {
        [Key]
        public int OptionId { get; set; }
        public string Option { get; set; } = null!;
        public string Animal { get; set; } = null!;
        public int QuestionId { get; set; }

        // Navigation property:
        public QuestionModel Question { get; set; } = null!;
    }
}
