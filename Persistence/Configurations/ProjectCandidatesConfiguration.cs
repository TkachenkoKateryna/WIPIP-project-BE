using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Constants;

namespace Persistence.Configurations
{
    public class ProjectCandidatesConfiguration : IEntityTypeConfiguration<ProjectCandidate>
    {
        public void Configure(EntityTypeBuilder<ProjectCandidate> builder)
        {
            builder.HasOne(pc => pc.Employee)
                .WithMany(e => e.Candidates)
                .HasForeignKey(pc => pc.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.Project)
                .WithMany(p => p.Candidates)
                .HasForeignKey(pc => pc.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new ProjectCandidate()
                {
                    Id = new Guid("be1aa540-754b-4563-accb-b907fc1ae742"),
                    FTE = 0.5,
                    EnglishLevel = EnglishLevel.UpperIntermidiate,
                    SkillId = Guid.Parse("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31"),
                    Proficiency = Proficiency.Middle,
                    InternalRate = 30,
                    ExternalRate = 45,
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")

                },
                new ProjectCandidate()
                {
                    Id = new Guid("be8ea9f3-640a-4079-a576-17836c78c82b"),
                    FTE = 0.5,
                    EnglishLevel = EnglishLevel.UpperIntermidiate,
                    SkillId = Guid.Parse("be8ea9f3-640a-4079-a576-17836c78c82b"),
                    Proficiency = Proficiency.Middle,
                    InternalRate = 30,
                    ExternalRate = 45,
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                },
                new ProjectCandidate()
                {
                    Id = new Guid("540d5334-8cf1-40ee-a88e-640b5e78dc2c"),
                    FTE = 1,
                    EnglishLevel = EnglishLevel.UpperIntermidiate,
                    SkillId = Guid.Parse("e69515d6-7b4a-48f1-96f1-a431d4db9c6c"),
                    Proficiency = Proficiency.Middle,
                    InternalRate = 30,
                    ExternalRate = 45,
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                });
        }
    }
}
