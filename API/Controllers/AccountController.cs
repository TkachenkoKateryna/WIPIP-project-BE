using Application.Interfaces;
using Application.Interfaces.Util;
using Domain.Dtos;
using Domain.Dtos.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTTokenService _jwtService;
        private readonly IFileStorageService _fileStorageService;

        private readonly string containerName = "wipipresources";

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IJWTTokenService jwtService,
            IFileStorageService fileStorageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
            _fileStorageService = fileStorageService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterDto registeDto)
        {
            if (await _userManager.Users.AllAsync(x => x.Email == registeDto.Email))
            {
                return BadRequest("Email taken");
            }
            if (await _userManager.Users.AllAsync(x => x.UserName == registeDto.Username))
            {
                return BadRequest("Username taken");
            }

            var user = new User
            {
                UserName = registeDto.Username,
                Email = registeDto.Email,
            };

            var passGen = await _userManager.CreateAsync(user, registeDto.Password);

            if (passGen.Succeeded)
            {
                if (registeDto.isLead)
                {
                    await _userManager.AddToRoleAsync(user, "Lead");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Manager");
                }

                return CreateUserObject(user);
            }

            return BadRequest("Problem regstering user");
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<UserResponse>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserObject(user);
        }

        [AllowAnonymous]
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            User user = await _userManager.FindByEmailAsync(changePassword.Email);

            if (user is null) return BadRequest("User not found");

            IdentityResult result =
                    await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);

            if (result.Succeeded)
            {
                User updatedUser = await _userManager.FindByEmailAsync(changePassword.Email);
                return Ok(CreateUserObject(updatedUser));
            }
            else
            {
                return BadRequest("Error while changing the password");
            }
        }

        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            if (user is null) return BadRequest("User not found");

            if (image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(image.FileName);
                    user.ImageLink = _fileStorageService.SaveFile(content, extension, containerName, image.ContentType);
                }
            }
            var updatedUser = await _userManager.UpdateAsync(user);
            return Ok(updatedUser);
        }

        private UserResponse CreateUserObject(User user)
        {
            return new UserResponse
            {
                UserName = user.UserName,
                ImageLink = user.ImageLink,
                Token = _jwtService.CreateToken(user),
                Email = user.Email,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault()
            };
        }
    }
}
