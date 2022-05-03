
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class ProjectRisk : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid RiskId { get; set; }
        public Risk Risk { get; set; }
    }
}
