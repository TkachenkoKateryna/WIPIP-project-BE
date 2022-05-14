using Domain.Dtos.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<UserResponse> Login(LoginRequest loginRequest);
    }
}
