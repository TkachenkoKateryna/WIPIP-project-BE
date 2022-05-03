using Domain.Constants;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Stakeholder : BaseEntity
    {
        public Stakeholder()
        {
            ProjectStakeholders = new List<ProjectStakeholder>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public Payment Payment { get; set; }

        public Engagement Engagement { get; set; }

        public StakeholderClass Class { get; set; }

        public ICollection<ProjectStakeholder> ProjectStakeholders { get; set; }
    }
}
