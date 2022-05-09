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

            builder.HasData(
                new Assumption
                {
                    Id = Guid.Parse("1c7ba364-c16a-454b-a325-a88af2c0640e"),
                    Description = "End users will be available to test during the time they agree to.",
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                },
                new Assumption()
                {
                    Id = Guid.Parse("7aeb7618-859a-4fb8-841d-de44920b7a1a"),
                    Description = "Project will follow agile methodology throughout execution.",
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                }
            );
        }
    }
}
