using Domain.Models.Constants;

namespace Domain.Models.Dtos.Stakeholder
{
    public class StakeholderRequest
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public string ImageLink { get; set; }

        public Payment? Payment { get; set; }

        public StakeholderCategory Category { get; set; }

        public StakeholderInterest Interest { get; set; }

        public StakeholderInfluence Influence { get; set; }

        public StakeholderClass? Class { get; set; }

        public CommunicationChannel? CommunicationChannel { get; set; }

        public StakeholderRole Role { get; set; }
    }
}
