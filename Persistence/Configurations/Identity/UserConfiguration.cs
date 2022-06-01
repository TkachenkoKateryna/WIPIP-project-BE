using Domain.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                      Email = "bob@test.com",
                      NormalizedEmail = "BOB@TEXT.COM",
                      RoleId = "967e08ad-b71e-46e8-8e80-ffdce9ab9e74"
                  },
                   new User
                   {
                       Id = "4f555f12-9168-49b1-9f17-b87904564904",
                       UserName = "jane",
                       NormalizedUserName = "JANE",
                       PasswordHash = new PasswordHasher<User>().HashPassword(null, "Pa$$w0rd"),
                       Email = "jane@test.com",
                       NormalizedEmail = "JANE@TEXT.COM",
                       RoleId = "09afe919-59ff-44b8-b656-c5e320c163a7"
                   },
                   new User
                   {
                       Id = "251f0a6f-d01c-4eaa-a697-95cb183ff6a9",
                       UserName = "alla",
                       NormalizedUserName = "ALLA",
                       PasswordHash = new PasswordHasher<User>().HashPassword(null, "Pa$$w0rd"),
                       Email = "alla@test.com",
                       NormalizedEmail = "ALLA@TEST.COM",
                       RoleId = "27a697ec-3ab1-4c03-9534-d3dd0d797fd6"
                   }
            );
        }
    }
}
