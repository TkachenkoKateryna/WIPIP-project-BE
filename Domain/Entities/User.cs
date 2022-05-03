using Domain.Entities.Util;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            RefreshTokens = new List<RefreshToken>();
        }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
