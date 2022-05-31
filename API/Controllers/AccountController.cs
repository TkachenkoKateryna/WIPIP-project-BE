﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using API.Controllers.Base;
using Domain.Models.Dtos.Identity;
using Domain.Models.Entities.Identity;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _jwtService;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJWTTokenService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<UserResponse>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            var userResponse = CreateUserObject(user);

            return userResponse;
        }

        [Authorize]
        [HttpGet("users")]
        public ActionResult<IEnumerable<UserResponse>> GetAllUsers()
        {
            var users = new List<UserResponse>();

            foreach (var user in _userManager.Users)
            {
                users.Add(CreateUserObject(user));
            }

            return users;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
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

            var passGen = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!passGen.Succeeded) return BadRequest("Problem registering user");

            if (registerRequest.IsLead)
            {
                await _userManager.AddToRoleAsync(user, "Lead");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Manager");
            }

            return CreateUserObject(user);

        }

        [AllowAnonymous]
        [HttpPost("users/{userId}")]
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
        [HttpPost("changePassword")]
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
                return Ok(CreateUserObject(updatedUser));
            }
            else
            {
                return BadRequest("Error while changing the password");
            }
        }
        private UserResponse CreateUserObject(User user)
        {
            return new UserResponse
            {
                UserName = user.UserName,
                ImageLink = user.ImageLink,
                Token = _jwtService.CreateToken(user),
                Email = user.Email,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault(),
            };
        }
        private bool CheckPassword(string newPassword, string confirmedPassword)
        {
            return newPassword.Equals(confirmedPassword);
        }
    }
}
