using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RiskConfiguration : IEntityTypeConfiguration<Risk>
    {
        public void Configure(EntityTypeBuilder<Risk> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.HasOne(r => r.RiskCategory)
                .WithMany(c => c.Risks)
                .HasForeignKey(d => d.RiskCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Risk()
                {
                    Id = new Guid("24b91b47-9e30-4080-b386-dd708f959de9"),
                    Title = "Stakeholder action delays project",
                    Impact = Impact.Major,
                    Likelihood = Likelihood.Rare,
                    Mitigation = "Identify stakeholders, analyze power and influence and create a stakeholder engagement plan. Project Board to authorise the plan. Revisit the plan at regular intervals to check all stakeholders are managed.",
                    RiskCategoryId = Guid.Parse("6e11c76b-648a-4778-a11e-c21db56e7c52")
                },
                new Risk()
                {
                    Id = new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39"),
                    Title = "Lack of resources",
                    Impact = Impact.Major,
                    Likelihood = Likelihood.Rare,
                    Mitigation = "Plan project team. Acknowledge problems to the HR team. Talk to other project managers whether their team members' fte is full.",
                    RiskCategoryId = Guid.Parse("0124991d-1191-4914-afb7-02ab237dc2a6")
                },
                new Risk()
                {
                    Id = new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e"),
                    Title = "Lack of communication",
                    Impact = Impact.Major,
                    Likelihood = Likelihood.Rare,
                    Mitigation = "Write a communication plan. Identify stakeholders early and make sure they are considered in the communication plan. Use most appropriate channel of communication for audience",
                    RiskCategoryId = Guid.Parse("3c4d64e1-fac2-4cc4-87fd-0186bec6429a")
                },
                new Risk()
                {
                    Id = new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326"),
                    Title = "Unplanned work that must be accommodated",
                    Impact = Impact.Major,
                    Likelihood = Likelihood.Rare,
                    Mitigation = "Attend project scheduling workshops.Document all assumptions made in planning and communicate to the project manager before project kick off.",
                    RiskCategoryId = Guid.Parse("6d464351-efef-43db-9113-0b2de42ef20d")
                });
        }
    }
}
