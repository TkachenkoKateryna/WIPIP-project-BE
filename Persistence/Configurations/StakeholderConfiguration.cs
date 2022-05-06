using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class StakeholderConfiguration : IEntityTypeConfiguration<Stakeholder>
    {
        public void Configure(EntityTypeBuilder<Stakeholder> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.HasData(
                new Stakeholder()
                {
                    Id = Guid.Parse("d0203d35-a1f3-4dda-bca6-f6da30177102"),
                    Name = "Gil Spencor",
                    Email = "gil@test.com",
                    Address = "Miami, Florida 92A",
                    Payment = Payment.LittleDelay,
                    Class = StakeholderClass.KeepSatisfied,
                    Engagement = Engagement.Pertiial
                },
                 new Stakeholder()
                 {
                     Id = Guid.Parse("d9b199e5-263e-4e59-bb38-9420f5acdfc0"),
                     Name = "Amanda Froid",
                     Email = "amanda@test.com",
                     Address = "Miami, Florida 92A",
                     Payment = Payment.LittleDelay,
                     Class = StakeholderClass.KeyPlayer,
                     Engagement = Engagement.Full
                 });
        }
    }
}
