using Domain.Models.Constants;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(p => p.ManagerId).IsRequired();
            builder.Property(p => p.Title).IsRequired();

            builder.HasMany(p => p.Milestones)
                .WithOne(m => m.Project)
                .HasForeignKey(m => m.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Deliverables)
              .WithOne(d => d.Project)
              .HasForeignKey(d => d.ProjectId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Assumptions)
              .WithOne(a => a.Project)
              .HasForeignKey(a => a.ProjectId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Objectives)
              .WithOne(o => o.Project)
              .HasForeignKey(o => o.ProjectId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Manager)
                .WithMany(m => m.Projects)
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Project
                {
                    Id = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f"),
                    Title = "PlanMyKids",
                    Description = "Planmykids project that helps parents with building itineraries for kids to different camps.",
                    ManagerId = "4f555f12-9168-49b1-9f17-b87904564904",
                    Status = ProjectStatus.Draft
                });
        }
    }
}
