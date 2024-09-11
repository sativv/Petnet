
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApi.Data;
using WebApi.Data.NewFolder;
using WebApi.Models;

using WebApi.Models.APIModels;
using WebApi.Repositories;
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
        private readonly ApplicationDbContext _context;
        private readonly BookmarkRepo _bookmarkRepo;
        private readonly InterestRepo _interestRepo;


        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService, ILogger<AccountController> logger, ApplicationDbContext _context, BookmarkRepo bookmarkRepo, InterestRepo interestRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _logger = logger;
            this._context = _context;
            _bookmarkRepo = bookmarkRepo;
            _interestRepo = interestRepo;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            // Hämta användaren med det angivna ID:t
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound(new { message = $"User with ID {id} not found." });
            }

            // Skapa en DTO för att returnera användarens information
            var userDTO = new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.IsPrivateSeller,
                user.IsVerified,
                user.OrganizationName,
                user.OrganizationNumber,
                user.PhoneNumber,
                user.QuizResult,
                user.City,
                user.Adress,
                user.BuisnessContact,
                user.Postcode,
                user.AboutMe
            };

            return Ok(userDTO);
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

            // Uppdatera uppfödaruppgifter om det finns i DTO:n
            if (updateUserDto.OrganizationNumber.HasValue)
            {
                user.OrganizationNumber = updateUserDto.OrganizationNumber.Value;
            }
            if (!string.IsNullOrEmpty(updateUserDto.OrganizationName))
            {
                user.OrganizationName = updateUserDto.OrganizationName;
            }
            if (!string.IsNullOrEmpty(updateUserDto.BuisnessContact))
            {
                user.BuisnessContact = updateUserDto.BuisnessContact;
            }
            if (!string.IsNullOrEmpty(updateUserDto.Adress))
            {
                user.Adress = updateUserDto.Adress;
            }
            if (updateUserDto.Postcode.HasValue)
            {
                user.Postcode = updateUserDto.Postcode.Value;
            }
            if (!string.IsNullOrEmpty(updateUserDto.City))
            {
                user.City = updateUserDto.City;
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

            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            var userDTO = new
            {
                user.Id,
                user.Email,
                user.UserName,
                isAdmin,
                user.IsPrivateSeller,
                user.IsVerified,
                user.OrganizationName,
                user.OrganizationNumber,
                user.PhoneNumber,
                user.QuizResult,
                user.City,
                user.Adress,
                user.BuisnessContact,
                user.Postcode,
                user.AboutMe
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

        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmail([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email is required.");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return Ok(new { exists = true });
            }

            return Ok(new { exists = false });
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please select a file.");
            }

            var filePath = Path.Combine("wwwroot/FileUploads", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { Message = "File uploaded successfully." });
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] IFormCollection form)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            // Extrahera textfält från form-data
            var email = form["Email"];
            var password = form["Password"];
            var isPrivateSeller = bool.TryParse(form["IsPrivateSeller"], out var privateeSeller) ? privateeSeller : (bool?)null;
            var isVerified = bool.TryParse(form["IsVerified"], out var verified) ? verified : (bool?)null;
            var organizationNumber = long.TryParse(form["OrganizationNumber"], out var orgNum) ? orgNum : (long?)null;
            var organizationName = form["OrganizationName"];
            var buisnessContact = form["BuisnessContact"];
            var adress = form["Adress"];
            var postcode = int.TryParse(form["Postcode"], out var postCode) ? postCode : (int?)null;
            var city = form["City"];
            var phoneNumber = form["PhoneNumber"];

            // Extrahera filer från form-data
            var files = form.Files;
            var fileModels = new List<FileModel>();

            if (files.Count > 0)
            {
                var uploadDir = Path.Combine("FileUploads");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                foreach (var file in files)
                {
                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(uploadDir, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        fileModels.Add(new FileModel
                        {
                            Name = fileName,
                            Type = file.ContentType,
                            Path = Path.Combine("/FileUploads", fileName),
                            UploadDate = DateTime.UtcNow
                        });
                    }
                }

            }
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                IsPrivateSeller = isPrivateSeller ?? false,
                IsVerified = isVerified ?? false,
                OrganizationNumber = organizationNumber ?? 0,
                OrganizationName = organizationName,
                BuisnessContact = buisnessContact,
                Adress = adress,
                Postcode = postcode ?? 0,
                City = city,
                PhoneNumber = phoneNumber
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Koppla filerna till den nya användaren
                foreach (var fileModel in fileModels)
                {
                    fileModel.ApplicationUserId = user.Id;
                }

                // Spara filerna i databasen
                _context.Files.AddRange(fileModels);
                await _context.SaveChangesAsync();
                return Ok("User registered successfully");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);

        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users
                .Select(u => new
                {
                    u.Id,
                    u.UserName,
                    u.IsVerified,
                    u.Email
                })
                .ToListAsync();

            return Ok(users);
        }



        [HttpGet("{id}/reviewsreceived")]
        public async Task<IActionResult> GetReviewsReceived(string id)
        {
            // Hämta användaren och inkludera recensionerna som mottagits
            var user = await _userManager.Users
                .Include(u => u.ReviewsRecieved)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ReviewsRecieved);
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



            ////generar en länk som användaren kan trycka med som kommer innehålla en email och en token
            //var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);


            var forgotPasswordLink = $"http://localhost:3000/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}";



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

        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {

            // Hittar användaren med resetPassword objektet 
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);


            if (user != null)
            {
                // metod som tar token och det nya passwordet för att reseta det. 
                var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                if (!resetPassResult.Succeeded)
                {
                    foreach (var error in resetPassResult.Errors)
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



        [HttpGet("me/bookmarks")]
        [Authorize]

        public async Task<IActionResult> GetAllBookmarksAsync()
        {
            // hämta användaren
            var user = await _userManager.GetUserIdAsync(await _userManager.GetUserAsync(User));

            if (user == null)
            {
                return NotFound();
            }

            //get favorites

            var bookmarks = await _bookmarkRepo.GetAllBookmarksAsync(user);


            return Ok(bookmarks);
        }

        [HttpGet("me/interests")]
        [Authorize]

        public async Task<IActionResult> GetAllInterestsAsync()
        {
            // hämta användaren
            var user = await _userManager.GetUserIdAsync(await _userManager.GetUserAsync(User));

            if (user == null)
            {
                return NotFound();
            }

            //get interests

            var interests = await _interestRepo.GetAllInterestsAsync(user);


            return Ok(interests);
        }







        [HttpPost("AddBookmark")]
        [Authorize]

        public async Task<IActionResult> AddBookmarkAsync([FromBody] int postId)
        {
            if (postId == null)
            {
                return BadRequest();
            }


            var user = await _userManager.GetUserAsync(User);
            BookmarkModel bookmarkToAdd = new BookmarkModel()
            {
                ApplicationUserId = user.Id,
                PostModelId = postId
            };

            var addedBookmark = await _bookmarkRepo.AddBookmarkAsync(bookmarkToAdd);
            await _bookmarkRepo.SaveChangesAsync();

            return Ok(addedBookmark);

        }


        [HttpDelete("RemoveBookmark/{Id}")]
        [Authorize]

        public async Task<IActionResult> RemoveBookmarkAsync(string Id)
        {
            var user = await _userManager.GetUserAsync(User);
            var bookmarkToRemove = await _bookmarkRepo.GetById(user.Id + Id);
            if (bookmarkToRemove == null)
            {
                return NotFound();

            }

            _bookmarkRepo.RemoveBookmarkAsync(bookmarkToRemove);
            await _bookmarkRepo.SaveChangesAsync();


            return Ok();

        }



    }
}
