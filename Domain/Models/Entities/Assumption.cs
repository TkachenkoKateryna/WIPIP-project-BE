using Domain.Models.Entities.Base;

namespace Domain.Models.Entities
{
    public class Assumption : BaseEntity
    {
        public string Description { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
