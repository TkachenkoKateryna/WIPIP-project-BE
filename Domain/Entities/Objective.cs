
using Domain.Constants;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Objective: BaseEntity
    {
        public string Description { get; set; }
        public Priority Priority { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
