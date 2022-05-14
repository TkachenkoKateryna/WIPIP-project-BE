using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.HasMany(s => s.Candidates)
                .WithOne(c => c.Skill)
                .HasForeignKey(c => c.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Skill()
                {
                    Id = new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31"),
                    Title = "React"
                },
                new Skill()
                {
                    Id = new Guid("be8ea9f3-640a-4079-a576-17836c78c82b"),
                    Title = "Redux"
                },
                new Skill()
                {
                    Id = new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c"),
                    Title = "C#"
                });
        }
    }
}
