using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
    {
        public void Configure(EntityTypeBuilder<Milestone> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(b => b.Activity).IsRequired();

            builder.HasData(
                new Milestone
                {
                    Id = Guid.Parse("e1969bcb-49eb-4d16-9d9e-50bd016516df"),
                    DueDate = new DateTime(),
                    Activity = "Project documentation approved",
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                },
                new Milestone
                {
                    Id = Guid.Parse("f05dce1f-ba10-46a8-9266-9bdc8335520a"),
                    DueDate = new DateTime(),
                    Activity = "Web version release",
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                });
        }
    }
}
