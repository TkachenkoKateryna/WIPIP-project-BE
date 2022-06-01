using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Entities.Identity
{
    public class User : IdentityUser
    {
        public User()
        {
            Projects = new List<Project>();
        }

        public string ImageLink { get; set; }

        public string RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
