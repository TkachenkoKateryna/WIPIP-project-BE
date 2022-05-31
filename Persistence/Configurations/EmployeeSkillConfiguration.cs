using Domain.Models.Constants;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkill>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.HasAlternateKey(es => new { es.EmployeeId, es.SkillId });

            builder.HasOne(s => s.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Skill)
                .WithMany(s => s.EmployeeSkills)
                .HasForeignKey(e => e.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new EmployeeSkill()
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = Guid.Parse("db366b85-04ef-4e28-9ef3-24a0174159f3"),
                    SkillId = Guid.Parse("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31"),
                    Primary = true,
                    Proficiency = Proficiency.Junior
                },
                new EmployeeSkill()
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = Guid.Parse("39ca7391-d752-402e-8ef6-0b255ebefa7f"),
                    SkillId = Guid.Parse("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31"),
                    Primary = true,
                    Proficiency = Proficiency.Senior
                },
                new EmployeeSkill()
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = Guid.Parse("39ca7391-d752-402e-8ef6-0b255ebefa7f"),
                    SkillId = Guid.Parse("be8ea9f3-640a-4079-a576-17836c78c82b"),
                    Primary = true,
                    Proficiency = Proficiency.Senior
                },
                new EmployeeSkill()
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = Guid.Parse("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"),
                    SkillId = Guid.Parse("e69515d6-7b4a-48f1-96f1-a431d4db9c6c"),
                    Primary = true,
                    Proficiency = Proficiency.Middle
                });
        }
    }
}
