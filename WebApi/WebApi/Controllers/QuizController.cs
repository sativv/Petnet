using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly QuizRepo quizRepo;

        public QuizController(QuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        [HttpGet("quizzes")]
        public async Task<IActionResult> GetQuizzes()
        {
            IEnumerable<QuizModel> quizzes = await quizRepo.GetQuizzesAsync();

            if (quizzes == null || !quizzes.Any())
            {
                return NotFound("No quizzes found.");
            }

            return Ok();
        }


        [HttpGet("quiz/{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            QuizModel quiz = await quizRepo.GetQuizByIdAsync(id);

            return Ok();
        }

        [HttpGet("questions by quiz/{id}")]
        public async Task<IActionResult> GetQuestions(int id)
        {
            IEnumerable<QuestionModel> questions = await quizRepo.GetQuestionsByIdAsync(id);

            return Ok();
        }

        [HttpGet("options by question/{id}")]
        public async Task<IActionResult> GetOptions(int id)
        {
            IEnumerable<OptionModel> options = await quizRepo.GetOptionsByIdAsync(id);

            return Ok();
        }

    }
}
