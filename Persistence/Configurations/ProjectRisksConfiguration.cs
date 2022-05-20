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

            builder.HasData(
                new ProjectRisk()
                {
                    Id = Guid.NewGuid(),
                    RiskId = new Guid("24b91b47-9e30-4080-b386-dd708f959de9"),
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                },
                new ProjectRisk()
                {
                    Id = Guid.NewGuid(),
                    RiskId = new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39"),
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                },
                new ProjectRisk()
                {
                    Id = Guid.NewGuid(),
                    RiskId = new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e"),
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                },
                new ProjectRisk()
                {
                    Id = Guid.NewGuid(),
                    RiskId = new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326"),
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                });
        }
    }
}
