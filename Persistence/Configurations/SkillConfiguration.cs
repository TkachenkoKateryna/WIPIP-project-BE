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
        }
    }
}
