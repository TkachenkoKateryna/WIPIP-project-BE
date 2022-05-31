using Domain.Models.Constants;

namespace Domain.Models.Dtos.Responses
{
    public class ObjectiveResponse
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public string Title { get; set; }
        public string ProjectId { get; set; }
    }
}
