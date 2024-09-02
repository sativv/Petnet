using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostRepo _postRepo;



        public PostController(PostRepo postRepo)
        {
            _postRepo = postRepo;
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


        // Make post 

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPostAsync([FromBody] PostModel postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }

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

    }
}
