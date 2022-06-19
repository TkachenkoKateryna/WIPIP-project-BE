using Domain.Models.Dtos.Responses;

namespace Domain.Models.Dtos.Identity
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageLink { get; set; }
        public string Role { get; set; }
        public string Id { get; set; }
    }
}
