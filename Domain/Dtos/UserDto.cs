using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Http;

namespace Domain.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Role { get; set; }
        public List<ProjectResponse> Projects { get; set; }
    }
}
