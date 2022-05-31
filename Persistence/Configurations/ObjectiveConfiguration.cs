using Domain.Models.Constants;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ObjectiveConfiguration : IEntityTypeConfiguration<Objective>
    {
        public void Configure(EntityTypeBuilder<Objective> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(b => b.Description).IsRequired();

            builder.HasData(
                new Objective
                {
                    Id = Guid.Parse("68bf002d-69f8-4d6d-8f15-6da8483767a2"),
                    Title = "Number of websites users",
                    Description = "Increase the number of website users to 100 in first three month",
                    Priority = Priority.Medium,
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                },
                new Objective
                {
                    Id = Guid.Parse("137edc09-5547-4eb0-8b60-ab4608cae052"),
                    Title = "Number of websites clients",
                    Description = "Increase the number of clients to 5 in first month",
                    Priority = Priority.Low,
                    ProjectId = Guid.Parse("340cf520-35e7-47f3-ad61-5e15d705cb6f")
                });
        }
    }
}
