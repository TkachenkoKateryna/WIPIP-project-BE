using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Identity
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
        public bool IsLead { get; set; }
    }
}
