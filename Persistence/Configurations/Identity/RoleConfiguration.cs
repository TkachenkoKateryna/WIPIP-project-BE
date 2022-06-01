using Domain.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

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
                },
                new IdentityRole
                {
                    Id = "27a697ec-3ab1-4c03-9534-d3dd0d797fd6",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}
