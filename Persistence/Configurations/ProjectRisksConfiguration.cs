using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProjectRisksConfiguration : IEntityTypeConfiguration<ProjectRisk>
    {
        public void Configure(EntityTypeBuilder<ProjectRisk> builder)
        {
            builder.HasOne(d => d.Project)
                .WithMany(m => m.ProjectRisks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Risk)
                .WithMany(m => m.ProjectRisks)
                .HasForeignKey(d => d.RiskId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
