using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Util;
using Domain.Dtos.Identity;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _jwtService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IUnitOfWork _uow;

        public AccountService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUnitOfWork uow,
            IJWTTokenService jwtService,
            IFileStorageService fileStorageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _uow = uow;
            _fileStorageService = fileStorageService;
        }

        public async Task<UserResponse> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null)
                throw new NotFoundException<User>($"User with {loginRequest.Email} has not been found");

            await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

            return CreateUserObject(user);
        }

        public UserResponse CreateUserObject(User user)
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
    }
}
