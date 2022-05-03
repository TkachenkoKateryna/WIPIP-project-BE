using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProjectStakeholdersConfigurationcs : IEntityTypeConfiguration<ProjectStakeholder>
    {
        public void Configure(EntityTypeBuilder<ProjectStakeholder> builder)
        {
            builder.HasOne(d => d.Project)
                .WithMany(m => m.ProjectStakeholders)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Stakeholder)
                .WithMany(m => m.ProjectStakeholders)
                .HasForeignKey(d => d.StakeholderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
