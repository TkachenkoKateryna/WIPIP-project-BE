using Domain.Models.Constants;

namespace Domain.Models.Dtos.Requests
{
    public class ObjectiveRequest
    {
        public Guid ProjectId { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public string Title { get; set; }
    }
}
