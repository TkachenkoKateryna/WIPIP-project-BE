using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                  new IdentityRole
                  {
                      Id = "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                      Name = "Manager",
                      NormalizedName = "MANAGER"
                  },
                    new IdentityRole
                    {
                        Id = "09afe919-59ff-44b8-b656-c5e320c163a7",
                        Name = "Lead",
                        NormalizedName = "LEAD"
                    }
            );
        }
    }
}
