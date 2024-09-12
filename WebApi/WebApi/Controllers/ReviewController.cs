using Microsoft.AspNetCore.Mvc;
using WebApi.Data.DTOs;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewRepo reviewRepo;

        public ReviewController(ReviewRepo reviewRepo)
        {
            this.reviewRepo = reviewRepo;
        }

        [HttpGet("reviews")]
        public async Task<IActionResult> GetReviews()
        {
            IEnumerable<ReviewModel> reviews = await reviewRepo.GetAllReviewsAsync();

            if (reviews == null || !reviews.Any())
            {
                return NotFound("No reviews found.");
            }
            return Ok(reviews);
        }

        // Make review

        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReviewAsync([FromBody] ReviewDTO reviewDto)
        {
            if (reviewDto == null)
            {
                return BadRequest("Review cannot be null.");
            }

            // Validera betyget
            if (reviewDto.Rating < 1 || reviewDto.Rating > 5)
            {
                return BadRequest("Rating must be between 1 and 5.");
            }

            // Konvertera ReviewDTO till ReviewModel
            var reviewModel = new ReviewModel
            {
                Content = reviewDto.Content,
                Rating = reviewDto.Rating,
                ReviewerId = reviewDto.ReviewerId,
                WrittenByUsername = reviewDto.WrittenByUsername,
                ReviewedSellerId = reviewDto.ReviewedSellerId,
            };

            // Lägg till recensionen i databasen
            var addedReview = await reviewRepo.AddReviewModelAsync(reviewModel);
            await reviewRepo.SaveChangesAsync(); // Se till att spara ändringarna i databasen

            return Ok(addedReview);
        }


        [HttpDelete("RemoveReview/{id}")]
        public async Task<IActionResult> RemoveReviewAsync(int id)
        {
            var reviewToRemove = await reviewRepo.GetReviewAsync(id);
            if (reviewToRemove == null)
            {
                return NotFound();
            }

            reviewRepo.RemoveReviewAsync(reviewToRemove);
            await reviewRepo.SaveChangesAsync();

            return Ok();
        }

        // endpoint för att hämta recensioner baserat på userId
        [HttpGet("user/{userId}/reviews")]
        public async Task<IActionResult> GetReviewsByUserId(string userId)
        {
            List<ReviewModel> reviews = await reviewRepo.GetReviewsByUserIdAsync(userId);

            if (reviews == null || reviews.Count == 0)
            {
                return NotFound($"No reviews found for user with ID {userId}.");
            }

            return Ok(reviews);
        }
    }
}

