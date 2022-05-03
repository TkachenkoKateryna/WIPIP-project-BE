using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Milestone : BaseEntity
    {
        public Milestone()
        {
            Deliverables = new List<Deliverable>();
        }

        public string Activity { get; set; }
        public DateTime DateTime { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<Deliverable> Deliverables { get; set; }
    }
}
