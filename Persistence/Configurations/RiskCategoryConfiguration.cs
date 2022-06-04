using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RiskCategoryConfiguration : IEntityTypeConfiguration<RiskCategory>
    {
        public void Configure(EntityTypeBuilder<RiskCategory> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.HasData(
                new RiskCategory
                {
                    Id = new Guid("94fd9fef-cbf0-4f34-a33c-dbb16b6b408f"),
                    Title = "Project goals Risks"
                },
                new RiskCategory
                {
                    Id = new Guid("072d2488-b193-4322-8132-dac1a5741a19"),
                    Title = "Budget Risk"
                },
                new RiskCategory
                {
                    Id = new Guid("73723c0a-935d-46f0-a580-d05d17c20fc6"),
                    Title = "Schedule Risk"
                },
                new RiskCategory
                {
                    Id = new Guid("77dbf4db-8b5c-4b5d-98e5-e8e4f9044713"),
                    Title = "Payment Risks"
                },
                new RiskCategory
                {
                    Id = new Guid("0124991d-1191-4914-afb7-02ab237dc2a6"),
                    Title = "Resource Risks"
                },
                new RiskCategory
                {
                    Id = new Guid("6e11c76b-648a-4778-a11e-c21db56e7c52"),
                    Title = "Stakeholder Risks"
                },
                new RiskCategory
                {
                    Id = new Guid("6d464351-efef-43db-9113-0b2de42ef20d"),
                    Title = "Scope Risks"
                },
                new RiskCategory
                {
                    Id = new Guid("3c4d64e1-fac2-4cc4-87fd-0186bec6429a"),
                    Title = "Communications Risks"
                },
                new RiskCategory
                {
                    Id = new Guid("8c23107a-01d6-488a-b48b-703598b73ef3"),
                    Title = "Assumptions Risks"
                });
        }
    }
}
