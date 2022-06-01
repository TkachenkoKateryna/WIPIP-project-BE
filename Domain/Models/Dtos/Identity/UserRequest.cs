using Domain.Models.Constants;
using Microsoft.AspNetCore.Http;

namespace Domain.Models.Dtos.Requests
{
    public class UserRequest
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public IFormFile ImageFile { get; set; }
        public Roles Role { get; set; }
    }
}
