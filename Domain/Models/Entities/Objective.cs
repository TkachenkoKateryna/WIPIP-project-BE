
using Domain.Models.Constants;
using Domain.Models.Entities.Base;

namespace Domain.Models.Entities
{
    public class Objective : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
