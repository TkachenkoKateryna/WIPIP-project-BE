using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);

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

   
        }
    }
}
