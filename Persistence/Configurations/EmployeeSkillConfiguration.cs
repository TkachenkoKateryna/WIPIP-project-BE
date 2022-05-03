using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkill>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.HasOne(d => d.Employee)
                .WithMany(m => m.EmployeeSkills)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Skill)
                .WithMany(m => m.EmployeeSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
