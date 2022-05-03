using Application.Interfaces.Util;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTTokenService _jwtService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IJWTTokenService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
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

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registeDto)
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
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserObject(user);
        }

        private UserDto CreateUserObject(User user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                Image = null,
                Token = _jwtService.CreateToken(user),
                Email = user.Email,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault()
            };
        }

    }
}
