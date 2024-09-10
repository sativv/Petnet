using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.DTOs;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class InterestRepo
    {
        private readonly ApplicationDbContext _context;

        public InterestRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InterestModel>> GetAll()
        {
            return await _context.Interests.ToListAsync();
        }

        public async Task<InterestModel> AddInterest(InterestModel interestToAdd)
        {
            _context.Interests.Add(interestToAdd);
            await _context.SaveChangesAsync();
            return interestToAdd;
        }

        public async Task RemoveInterest(InterestModel interestToremove)
        {
            _context.Remove(interestToremove);
            await _context.SaveChangesAsync();

        }

        public async Task<List<InterestModel>> GetByPost(int postId)
        {
            return await _context.Interests.Where(i => i.PostId == postId).ToListAsync();
        }

        public async Task<List<int>> GetAllInterestsAsync(string userId)
        {
            List<int> interests = new();

            await _context.Interests.Where(i => i.ApplicationUserId == userId).ForEachAsync(i =>
            {
                interests.Add(i.PostId);
            });
            return interests;
        }
    }
}
