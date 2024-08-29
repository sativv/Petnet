using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class QuizModel
    {
        [Key]
        public int QuizId { get; set; }

        public string Title { get; set; } = null!;
        public string Info { get; set; } = null!;
        public string Dog { get; set; }
        public string Cat { get; set; }

        public string Rabbit { get; set; }
        public string Bird { get; set; }
        public string Aquarium { get; set; }
        public string Reptile { get; set; }



        public List<QuestionModel> Questions { get; set; } = null!;
    }
}
