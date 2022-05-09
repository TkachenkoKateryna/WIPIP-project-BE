using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Deliverable : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeOfComplition { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid? MilestoneId { get; set; }
        public Milestone Milestone { get; set; }
    }
}
