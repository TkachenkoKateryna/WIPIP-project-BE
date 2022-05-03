using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ProjectCandidatesConfiguration : IEntityTypeConfiguration<ProjectCandidate>
    {
        public void Configure(EntityTypeBuilder<ProjectCandidate> builder)
        {
            builder.HasOne(d => d.Employee)
                .WithMany(m => m.Candidates)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Project)
                .WithMany(m => m.Candidates)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
