using Domain.Entities.Base;

namespace Domain.Entities
{
    public class ProjectStakeholder : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid StakeholderId { get; set; }
        public Stakeholder Stakeholder { get; set; }
    }
}
