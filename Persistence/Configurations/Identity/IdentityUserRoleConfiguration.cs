using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Identity
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                  new IdentityUserRole<string>
                  {
                      RoleId = "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                      UserId = "4f555f12-9168-49b1-9f17-b87904564904"
                  },
                  new IdentityUserRole<string>
                  {
                      RoleId = "09afe919-59ff-44b8-b656-c5e320c163a7",
                      UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                  }
            );
        }
    }
}
