using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DeliverableConfiguration : IEntityTypeConfiguration<Deliverable>
    {
        public void Configure(EntityTypeBuilder<Deliverable> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.HasOne(d => d.Milestone)
                .WithMany(m => m.Deliverables)
                .HasForeignKey(d => d.MilestoneId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
