using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Data.DTOs;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly InterestRepo _interestRepo;
        private readonly PostRepo _postRepo;

        public InterestController(UserManager<ApplicationUser> usermanager, InterestRepo interestRepo, PostRepo postRepo)
        {
            _usermanager = usermanager;
            _interestRepo = interestRepo;
            _postRepo = postRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _interestRepo.GetAll());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddInterest([FromBody] InterestDTO interestDTO)
        {
            if(interestDTO == null)
            {
                return BadRequest("Body was null");
            }

            

            interestDTO.ApplicationUserId = await _usermanager.GetUserIdAsync(await _usermanager.GetUserAsync(User));

            Console.WriteLine(interestDTO.ApplicationUserId);

            return Ok(await _interestRepo.AddInterest(new InterestModel { ApplicationUserId = interestDTO.ApplicationUserId, PostId = interestDTO.PostId }));
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveInterest([FromBody] InterestDTO interestDTO)
        {
            if(interestDTO == null)
            {
                return BadRequest();
            }
            if (interestDTO.ApplicationUserId != await _usermanager.GetUserIdAsync(await _usermanager.GetUserAsync(User))) 
            {
                return BadRequest("Cant remove an interest you don't own");
            }

            await _interestRepo.RemoveInterest(new InterestModel { ApplicationUserId = interestDTO.ApplicationUserId, PostId = interestDTO.PostId });
            return Ok();
        }

        [HttpGet("GetByPost/{postId}")]
        [Authorize]
        public async Task<IActionResult> GetByPost(int postId)
        {
            var post = await _postRepo.GetPostAsync(postId);

            if(post.ApplicationUserId != await _usermanager.GetUserIdAsync(await _usermanager.GetUserAsync(User)))
            {
                return BadRequest();
            }
            
            return Ok(await _interestRepo.GetByPost(postId));
        }
    }
}
