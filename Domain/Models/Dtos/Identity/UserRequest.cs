using Domain.Models.Constants;

namespace Domain.Models.Dtos.Identity
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageLink { get; set; }
        public string Role { get; set; }
    }
}
