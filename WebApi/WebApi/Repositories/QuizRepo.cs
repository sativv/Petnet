using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class QuizRepo
    {
        private ApplicationDbContext context;

        public QuizRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<QuizModel>> GetQuizzesAsync()
        {
            List<QuizModel> quizzes = await context.Quizzes.ToListAsync();

            return quizzes;
        }
        public async Task<QuizModel> GetQuizByIdAsync(int id)
        {
            QuizModel quiz = await context.Quizzes.FirstOrDefaultAsync(quiz => quiz.QuizId == id);

            return quiz;
        }

        public async Task<IEnumerable<QuestionModel>> GetQuestionsByIdAsync(int id)
        {
            List<QuestionModel> questions = await context.Questions.Where(question => question.QuizId == id).ToListAsync();

            return questions;
        }


        public async Task<IEnumerable<OptionModel>> GetOptionsByIdAsync(int id)
        {
            List<OptionModel> options = await context.Options.Where(option => option.QuestionId == id).ToListAsync();

            return options;
        }



    }
}
