using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class QuestionModel
    {
        [Key]
        public int QuestionId { get; set; }
        public string Text { get; set; } = null!;
        public List<OptionModel> Options { get; set; } = new List<OptionModel>();
        public int QuizId { get; set; }

        // Navigation property
        public QuizModel Quiz { get; set; } = null!;
    }
}
