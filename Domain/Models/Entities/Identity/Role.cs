using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Entities.Identity
{
    public class Role : IdentityRole
    {
        public Role()
        {
            Users = new List<User>();
        }
        public ICollection<User> Users { get; set; }
    }
}
