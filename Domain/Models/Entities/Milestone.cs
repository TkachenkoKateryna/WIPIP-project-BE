using Domain.Models.Entities.Base;

namespace Domain.Models.Entities
{
    public class Milestone : BaseEntity
    {
        public Milestone()
        {
            Deliverables = new List<Deliverable>();
        }

        public string Activity { get; set; }
        public DateTime DueDate { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<Deliverable> Deliverables { get; set; }
    }
}
