using Domain.Models.Dtos.Project;
using Domain.Models.Dtos.Responses;
using Microsoft.AspNetCore.Http;

namespace Domain.Models.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Role { get; set; }
        public List<ProjectsResponse> Projects { get; set; }
    }
}
