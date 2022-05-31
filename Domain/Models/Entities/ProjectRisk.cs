
using Domain.Models.Entities.Base;

namespace Domain.Models.Entities
{
    public class ProjectRisk : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid RiskId { get; set; }
        public Risk Risk { get; set; }
    }
}
