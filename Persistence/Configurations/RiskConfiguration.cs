using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RiskConfiguration : IEntityTypeConfiguration<Risk>
    {
        public void Configure(EntityTypeBuilder<Risk> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.HasOne(r => r.RiskCategory)
                .WithMany(c => c.Risks)
                .HasForeignKey(d => d.RiskCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
