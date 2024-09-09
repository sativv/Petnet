using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{


    public class BookmarkRepo
    {

        private readonly ApplicationDbContext _context;

        public BookmarkRepo(ApplicationDbContext context)

        {
            _context = context;

        }




        //Get all interests based on userid

        public async Task<List<int>> GetAllBookmarksAsync(string userId)
        {
            List<int> bookmarks = new();


            await _context.Bookmarks.Where(b => b.ApplicationUserId == userId).ForEachAsync(b =>
           {
               bookmarks.Add(b.PostModelId);
           });
            return bookmarks;

        }



        public async Task<BookmarkModel> AddBookmarkAsync(BookmarkModel bookmarkToAdd)
        {
            await _context.Bookmarks.AddAsync(bookmarkToAdd);
            return bookmarkToAdd;
        }


        public void RemoveBookmarkAsync(BookmarkModel bookmarkToRemove)
        {
            _context.Bookmarks.Remove(bookmarkToRemove);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<BookmarkModel?> GetById(string Id)
        {
            return await _context.Bookmarks.FirstOrDefaultAsync(b => b.ApplicationUserId + b.PostModelId == Id);
        }

    }


}
