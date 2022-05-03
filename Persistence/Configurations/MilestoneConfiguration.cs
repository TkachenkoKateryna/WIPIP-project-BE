using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
    {
        public void Configure(EntityTypeBuilder<Milestone> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
