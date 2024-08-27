using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class QuizModel
    {
        [Key]
        public int QuizId { get; set; }

        public string Title { get; set; } = null!;
        public string Info { get; set; } = null!;


        public List<QuestionModel> Questions { get; set; } = null!;
    }
}
