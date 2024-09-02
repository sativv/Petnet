
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Data;
using WebApi.Data.NewFolder;
using WebApi.Models;
using WebApi.Service.Models;
using WebApi.Service.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;


        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IEmailService emailService , ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPatch("me/about")]
        [Authorize]
        public async Task<IActionResult> UpdateAboutMe([FromBody] UpdateUserDTO updateUserDto)
        {
            // Hämta den inloggade användaren
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            // Uppdatera AboutMe-fältet om det finns i DTO:n
            if (!string.IsNullOrEmpty(updateUserDto.AboutMe))
            {
                user.AboutMe = updateUserDto.AboutMe;
            }

            // Spara ändringarna
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return ValidationProblem(ModelState);
            }

            return NoContent(); // uppdateringen lyckades
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



        //  Testa email sendern 

        [HttpGet("TestSendEmail")] 
        public IActionResult TestEmail()
        {
            var message = new Message(new string[]

            {"alinia93@gmail.com"}, "Test", "<h1> Subscribe to my channel</h1>");
            
               

           
            _emailService.SendEmail(message);

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Sucess", Message = "Email sent Succesfully" });
        }


        //
        // Denna endpoint används för att skicka en förfrågan om att få ändra password. 

        [HttpPost("forgot-password")]
         [AllowAnonymous] // Detta betyder att alla kan använda denna endpoint även om man inte är inloggad
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {

            // sök efter user med mailen som skickas in. 
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
              new Response { Status = "Error", Message = "Could not send link to email. Please try again. " });

            }

            // skapar en token för användarens lösenord 
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);



            // generar en länk som användaren kan trycka med som kommer innehålla en email och en token 
            var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);


            if (string.IsNullOrEmpty(forgotPasswordLink))
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "Failed to generate reset password link." });
            }


            // Skapar ett meddelande med bland annat länken 
            var message = new Message(new string[] { user.Email! }, "Forgot password link", forgotPasswordLink!);
            // Skickar mailet 
            _emailService.SendEmail(message);


            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Sucess", Message = $"Password changed request is sent on email {user.Email}. Please open your email and click on the link. " });
        }





        [HttpGet("reset-password")]

        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };

            return Ok(model);
        }


 
        [HttpPost]
        [AllowAnonymous]
        [Route("reset-password")]
        
        public async Task <IActionResult> ResetPassword(ResetPassword resetPassword)
        {

            // Hittar användaren med resetPassword objektet 
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);


            if (user != null)
            {
               // metod som tar token och det nya passwordet för att reseta det. 
                var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                if ( !resetPassResult.Succeeded)
                {
                    foreach(var error in resetPassResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                       
                    }
                    return Ok(ModelState);
                }

                return StatusCode(StatusCodes.Status200OK,
          new Response { Status = "Sucess", Message = "Password has been changed!" });
            }

            return StatusCode(StatusCodes.Status400BadRequest,
                new Response { Status = "Error", Message = "Something went wrong" });
        }



    }
}
