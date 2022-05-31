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

        public IEnumerable<Project> Projects { get; set; }
    }
}
