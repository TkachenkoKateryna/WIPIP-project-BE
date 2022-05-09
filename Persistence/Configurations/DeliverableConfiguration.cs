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

            builder.HasData(
                    new Deliverable
                    {
                        Id = Guid.Parse("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                        Title = "Project Plan",
                        Description = "Detailed description of project activities and their delivery process.",
                        TimeOfComplition = DateTime.UtcNow + TimeSpan.FromDays(14),
                        ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f"),
                        MilestoneId = Guid.Parse("e1969bcb-49eb-4d16-9d9e-50bd016516df")
                    },
                    new Deliverable
                    {
                        Id = Guid.Parse("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                        Title = "Web application",
                        Description = "Web Application with full functionality described in documentation.",
                        TimeOfComplition = DateTime.UtcNow + TimeSpan.FromDays(200),
                        ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f"),
                        MilestoneId = Guid.Parse("f05dce1f-ba10-46a8-9266-9bdc8335520a")
                    },
                    new Deliverable
                    {
                        Id = Guid.Parse("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                        Title = "Desktop Application.",
                        Description = "Desktop Application with full functionality described in documentation.",
                        TimeOfComplition = DateTime.UtcNow + TimeSpan.FromDays(200),
                        ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                    });
        }
    }
}
