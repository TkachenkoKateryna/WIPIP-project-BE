using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AssumptionConfiguration : IEntityTypeConfiguration<Assumption>
    {
        public void Configure(EntityTypeBuilder<Assumption> builder) 
        {
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
