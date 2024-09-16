using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostRepo _postRepo;
        private readonly UserManager<ApplicationUser> _usermanager;

        public PostController(PostRepo postRepo, UserManager<ApplicationUser> usermanager)
        {
            _postRepo = postRepo;
            _usermanager = usermanager;
        }

        //Get one post

        [HttpGet("SinglePost/{id}")]

        public async Task<IActionResult> GetPostAsync(int id)
        {
            PostModel? post = await _postRepo.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            else
            {

                return Ok(post);

            }

        }

        [HttpPost("AllPostByIds")]
        public async Task<IActionResult> GetPostsByIds([FromBody] List<int> PostIds)
        {
            if (PostIds == null || PostIds.Count == 0)
            {
                return BadRequest("Post ids are required");
            }

            var posts = await _postRepo.GetAllPostsAsync();
            var matchingPosts = posts.Where(p => PostIds.Contains(p.Id)).ToList();

            return Ok(matchingPosts);
        }

        // Get all posts
        [HttpGet]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            List<PostModel> allPosts = await _postRepo.GetAllPostsAsync();
            if (allPosts == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(allPosts);
            }
        }


        // UpdatePost a post 
        [HttpPut("UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePostAsync(int id, [FromBody] PostModel postModel)
        {
            if (postModel == null || id != postModel.Id)
            {
                return BadRequest();
            }

            var updatedPost = await _postRepo.UpdatePostAsync(postModel);
            if (updatedPost == null)
            {
                return NotFound();
            }

            await _postRepo.SaveChangesAsync();

            return Ok(updatedPost);
        }

        //[HttpGet("AdminTest")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> AdminTest()
        //{
        //    return Ok("Ur admin");
        //}




        // Make post 

        [HttpPost("AddPost")]
        [Authorize]
        public async Task<IActionResult> AddPostAsync([FromBody] PostModel postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }
            postModel.ApplicationUser = await _usermanager.GetUserAsync(User);

            var addedPost = await _postRepo.AddPostModelAsync(postModel);
            await _postRepo.SaveChangesAsync();  // Se till att spara ändringarna i databasen

            return Ok(addedPost);
        }


        // Remove post 


        [HttpDelete("RemovePost/{id}")]
        public async Task<IActionResult> RemovePostAsync(int id)
        {
            var postToRemove = await _postRepo.GetPostAsync(id);
            if (postToRemove == null)
            {
                return NotFound();
            }

            _postRepo.RemovePostAsync(postToRemove);
            await _postRepo.SaveChangesAsync();

            return Ok();
        }

        // Get own posts

        [HttpGet("Own")]
        [Authorize]
        public async Task<IActionResult> GetOwnPosts()
        {
            var currentUser = await _usermanager.GetUserAsync(User);

            if(currentUser == null || currentUser.Id == null)
            {
                return BadRequest();
            }


            return Ok(await _postRepo.GetByUser(currentUser.Id));
        }
    }
}
