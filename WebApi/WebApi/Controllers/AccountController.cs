using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models.APIModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new
            {
                user.Id,
                user.Email,
                user.UserName
            };

            return Ok(userDTO);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser userObject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = userObject.Email,
                Email = userObject.Email,
                IsPrivateSeller = userObject.IsPrivateSeller,
                OrganizationNumber = userObject.OrganizationNumber,
                OrganizationName = userObject.OrganizationName,
                BuisnessContact = userObject.BuisnessContact,
                Adress = userObject.Adress,
                Postcode = userObject.Postcode,
                City = userObject.City,
                PhoneNumber = userObject.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, userObject.Password);

            if (result.Succeeded)
            {
                return Ok("User registered successfully");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);



        }

        [HttpPut("update/quizResultByUserId/{id}")]
        public async Task<IActionResult> UpdateUsersQuizResult(string id, [FromBody] QuizResultModel qResult)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { message = $"User with ID {id} not found." });

            user.QuizResult = qResult.QuizResult;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { message = "User quiz result updated successfully" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

    }
}
