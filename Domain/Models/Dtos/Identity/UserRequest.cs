using Domain.Models.Constants;
using Microsoft.AspNetCore.Http;

namespace Domain.Models.Dtos.Requests
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageLink { get; set; }
        public string Role { get; set; }
    }
}
