using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProjectStakeholdersConfigurationcs : IEntityTypeConfiguration<ProjectStakeholder>
    {
        public void Configure(EntityTypeBuilder<ProjectStakeholder> builder)
        {
            builder.HasAlternateKey(ps => new { ps.ProjectId, ps.StakeholderId });

            builder.HasOne(d => d.Project)
                .WithMany(m => m.ProjectStakeholders)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Stakeholder)
                .WithMany(m => m.ProjectStakeholders)
                .HasForeignKey(d => d.StakeholderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new ProjectStakeholder()
                {
                    Id = Guid.Parse("c32fee26-6fb9-4140-8354-db07140c6f28"),
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f"),
                    StakeholderId = Guid.Parse("d0203d35-a1f3-4dda-bca6-f6da30177102")
                },
                new ProjectStakeholder()
                {
                    Id = Guid.Parse("dddada16-713b-4a0c-a6e5-5462304f4a18"),
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f"),
                    StakeholderId = Guid.Parse("d9b199e5-263e-4e59-bb38-9420f5acdfc0")
                });
        }
    }
}
