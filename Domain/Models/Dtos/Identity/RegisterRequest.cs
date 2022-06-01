using Domain.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Dtos.Identity
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
        public Roles Role { get; set; }
    }
}
