using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ReviewRepo
    {

        private readonly ApplicationDbContext _context;

        public ReviewRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // get review by userid
        public async Task<List<ReviewModel>> GetReviewsByUserIdAsync(string userId)
        {
            // Hämta recensioner där ReviewedSellerId matchar userId
            return await _context.Reviews
                .Where(r => r.ReviewedSellerId == userId)
                .ToListAsync();
        }



        // Get one review
        public async Task<ReviewModel?> GetReviewAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);
        }


        // Gets all reviews

        public async Task<List<ReviewModel>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }


        // Make a review 

        public async Task<ReviewModel> AddReviewModelAsync(ReviewModel reviewModelToAdd)
        {
            await _context.Reviews.AddAsync(reviewModelToAdd);
            return reviewModelToAdd;
        }


        // Remove review 

        public void RemoveReviewAsync(ReviewModel reviewToRemove)
        {

            _context.Reviews.Remove(reviewToRemove);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
