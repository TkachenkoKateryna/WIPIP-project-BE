using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using API.Controllers.Base;
using Domain.Models.Dtos.Identity;
using Domain.Models.Entities.Identity;
using Domain.Interfaces.Services.Util;
using Domain.Models.Dtos.Responses;
using Domain.Models.Constants;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _jwtService;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJWTTokenService jwtService,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }

        [Authorize]
        [HttpGet(Strings.UserRoute)]
        public async Task<ActionResult<UserResponse>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            var role = await _roleManager.FindByIdAsync(user.RoleId);

            var userResponse = CreateUserObject(user, role.Name);

            return userResponse;
        }

        [Authorize]
        [HttpGet(Strings.UsersRoute)]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {
            var users = new List<UserResponse>();

            foreach (var user in _userManager.Users.ToList())
            {
                var role = await _roleManager.FindByIdAsync(user.RoleId);
                users.Add(CreateUserObject(user, role.Name));
            }

            return users;
        }


        [Authorize]
        [HttpGet(Strings.ManagersRoute)]
        public async Task<IEnumerable<ManagerResponse>> GetAllManagers()
        {
            var managers = new List<ManagerResponse>();

            foreach (var manager in _userManager.Users.ToList())
            {
                var role = await _roleManager.FindByIdAsync(manager.RoleId);
                managers.Add(CreateManagerObject(manager, role.Name));
            }

            return managers;
        }

        [AllowAnonymous]
        [HttpPost(Strings.LoginRoute)]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
        {
            var users = _userManager.Users.ToList();

            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

            if (result.Succeeded)
            {
                var role = await _roleManager.FindByIdAsync(user.RoleId);
                return CreateUserObject(user, role.Name);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost(Strings.RegisterRoute)]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest registerRequest)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email.Equals(registerRequest.Email)))
            {
                return BadRequest("Email taken");
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName.Equals(registerRequest.Email)))
            {
                return BadRequest("Username taken");
            }

            var user = new User
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
            };

            switch (registerRequest.Role)
            {
                case Roles.Admin:
                    user.RoleId = await GetRoleId(Strings.AdminRole);
                    break;
                case Roles.Lead:
                    user.RoleId = await GetRoleId(Strings.LeadRole);
                    break;
                case Roles.Manager:
                    user.RoleId = await GetRoleId(Strings.ManagerRole);
                    break;
            }

            var passGen = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!passGen.Succeeded) return BadRequest("Problem registering user");

            var role = await _roleManager.FindByIdAsync(user.RoleId);

            return CreateUserObject(user, role.Name);
        }

        [AllowAnonymous]
        [HttpPost(Strings.UsersRoute + "{userId}")]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                return Ok(await _userManager.DeleteAsync(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost(Strings.ChangePasswordRoute)]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePassword)
        {
            User user = await _userManager.FindByEmailAsync(changePassword.Email);

            if (user is null) return BadRequest("User not found");

            if (!CheckPassword(changePassword.NewPassword, changePassword.OldPassword))
            {
                return BadRequest("Passwords are not equal");
            }

            var result =
                    await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);

            if (result.Succeeded)
            {
                var updatedUser = await _userManager.FindByEmailAsync(changePassword.Email);
                var role = await _roleManager.FindByIdAsync(user.RoleId);

                return Ok(CreateUserObject(updatedUser, role.Name));
            }
            else
            {
                return BadRequest("Error while changing the password");
            }
        }

        private UserResponse CreateUserObject(User user, string roleName)
        {
            return new UserResponse
            {
                UserName = user.UserName,
                ImageLink = user.ImageLink,
                Token = _jwtService.CreateToken(user),
                Email = user.Email,
                Role = roleName,
            };
        }

        private ManagerResponse CreateManagerObject(User user, string roleName)
        {
            return new ManagerResponse
            {
                Id = user.Id,
                Name = user.UserName,
                Role = roleName
            };
        }

        private bool CheckPassword(string newPassword, string confirmedPassword)
        {
            return newPassword.Equals(confirmedPassword);
        }

        private async Task<string> GetRoleId(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            return role.Id;
        }
    }

}
