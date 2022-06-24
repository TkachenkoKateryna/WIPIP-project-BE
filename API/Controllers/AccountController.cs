using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Domain.Models.Entities.Identity;
using Domain.Interfaces.Services.Util;
using Domain.Models.Dtos.Responses;
using Domain.Models.Constants;
using Domain.Models.Dtos.Requests;
using Domain.Models.Exceptions;
using Domain.Models.Dtos.Identity;
using API.Extensions;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class AccountController : ControllerBase
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
        [HttpPut(Strings.UserRoute + "{userId}")]
        public async Task<ActionResult<UserResponse>> UpdateUser(UserRequest userRequest, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null) throw new NotFoundException("User was not found");

            if (_userManager.Users.Any(user => user.Email == userRequest.Email & user.Id != userId))
            {
                throw new AlreadyExistsException("User with such email already exists", "email");
            }

            if (_userManager.Users.Any(user => user.UserName == userRequest.Name & user.Id != userId))
            {
                throw new AlreadyExistsException("User with such username already exists", "name");
            }

            await _userManager.SetEmailAsync(user, userRequest.Email);
            //user.Email = userRequest.Email;
            //user.NormalizedEmail = userRequest.Email.ToUpper();
            user.UserName = userRequest.Name;
            user.NormalizedUserName = userRequest.Name.ToUpper();
            user.ImageLink = userRequest.ImageLink;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var updatedUser = await _userManager.FindByIdAsync(userId);
                var role = await _roleManager.FindByIdAsync(user.RoleId);

                return Ok(CreateUserObject(updatedUser, role.Name));
            }
            else
            {
                throw new BadRequestException("Error while updating user");
            }
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
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            _ = _userManager.Users.ToList();

            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null) throw new NotFoundException("User was not found");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

            if (result.Succeeded)
            {
                return _jwtService.CreateToken(user);
            }

            throw new UnathorizedException("Error while authorization. Check username or email.");
        }

        [AllowAnonymous]
        [HttpPost(Strings.RegisterRoute)]
        public async Task<ActionResult<string>> Register(RegisterRequest registerRequest)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email.Equals(registerRequest.Email)))
            {
                throw new AlreadyExistsException("User with such email already exists", "email");
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName.Equals(registerRequest.Username)))
            {
                throw new AlreadyExistsException("User with such user name already exists", "username");
            }

            var user = new User
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
            };

            switch (registerRequest.Role)
            {
                case "Admin":
                    user.RoleId = await GetRoleId(Strings.AdminRole);
                    break;
                case "Lead":
                    user.RoleId = await GetRoleId(Strings.LeadRole);
                    break;
                case "Manager":
                    user.RoleId = await GetRoleId(Strings.ManagerRole);
                    break;
            }

            var passGen = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!passGen.Succeeded) return BadRequest("Problem registering user");

            return _jwtService.CreateToken(user);
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
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user is null) return BadRequest("User not found");

            if (!CheckPassword(changePassword.NewPassword, changePassword.ConfirmPassword))
            {
                throw new BadRequestException("Passwords are not equal", "confirmPassword");
            }

            var result =
                    await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);

            if (result.Succeeded)
            {
                var updatedUser = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var role = await _roleManager.FindByIdAsync(user.RoleId);

                return Ok(CreateUserObject(updatedUser, role.Name));
            }
            else
            {
                throw new BadRequestException("Error while changing the password. Check the old passsword.");
            }
        }

        private UserResponse CreateUserObject(User user, string roleName)
        {
            return new UserResponse
            {
                Name = user.UserName,
                ImageLink = user.ImageLink,
                Email = user.Email,
                Role = roleName,
                Id = user.Id
            };
        }

        private static ManagerResponse CreateManagerObject(User user, string roleName)
        {
            return new ManagerResponse
            {
                Id = user.Id,
                Name = user.UserName,
                Role = roleName
            };
        }

        private static bool CheckPassword(string newPassword, string confirmedPassword)
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
