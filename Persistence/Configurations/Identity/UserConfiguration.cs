using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                  new User
                  {
                      Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                      UserName = "bob",
                      NormalizedUserName = "BOB",
                      PasswordHash = new PasswordHasher<User>().HashPassword(null, "Pa$$w0rd"),
                      Email = "bob@text.com",
                      NormalizedEmail = "BOB@TEXT.COM"
                  },
                   new User
                   {
                       Id = "4f555f12-9168-49b1-9f17-b87904564904",
                       UserName = "jane",
                       NormalizedUserName = "JANE",
                       PasswordHash = new PasswordHasher<User>().HashPassword(null, "Pa$$w0rd"),
                       Email = "jane@text.com",
                       NormalizedEmail = "JANE@TEXT.COM"
                   }
            );
        }
    }
}
