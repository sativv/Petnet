using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class PostRepo
    {

        private readonly ApplicationDbContext _context;

        public PostRepo(ApplicationDbContext context)
        {
            _context = context; 
        }

        // Get one post 
        public async Task<PostModel?> GetPostAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }


        // Gets all posts 

        public async Task<List<PostModel>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }




        // Make a post 

        public async Task<PostModel> AddPostModelAsync(PostModel postModelToAdd)
        {
            await _context.Posts.AddAsync(postModelToAdd);
            return postModelToAdd;
        }
        // Update post 
        public async Task<PostModel> UpdatePostAsync(PostModel postToUpdate)
        {
            var currentPost = await GetPostAsync(postToUpdate.Id);
            currentPost = postToUpdate;
            return currentPost;
        }


        // Remove post 

        public void RemovePostAsync(PostModel postToRemove)
        {

            _context.Posts.Remove(postToRemove);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
