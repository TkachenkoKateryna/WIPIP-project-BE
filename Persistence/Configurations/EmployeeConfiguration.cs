using Domain.Models.Constants;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Email).IsRequired();

            builder.HasData(
                new Employee()
                {
                    Id = new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"),
                    Name = "Kate",
                    DFD = new DateTime(2022, 05, 16),
                    DOB = new DateTime(1997, 06, 15),
                    Email = "kate@gmail.com",
                    EnglishLevel = EnglishLevel.Intermidiate,
                    ImageLink = null,
                    Phone = "0996522354"
                },
                new Employee()
                {
                    Id = new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"),
                    Name = "Yura",
                    DFD = new DateTime(2021, 07, 26),
                    DOB = new DateTime(2000, 04, 16),
                    Email = "yura@gmail.com",
                    EnglishLevel = EnglishLevel.Intermidiate,
                    ImageLink = null,
                    Phone = "0996844525"
                },
                new Employee()
                {
                    Id = new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"),
                    Name = "Sveta",
                    DFD = new DateTime(2020, 06, 25),
                    DOB = new DateTime(2000, 02, 25),
                    Email = "sveta@gmail.com",
                    EnglishLevel = EnglishLevel.Intermidiate,
                    ImageLink = null,
                    Phone = "0996522147"
                });
        }
    }
}
