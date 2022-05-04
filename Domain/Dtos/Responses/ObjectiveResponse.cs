using Domain.Constants;

namespace Domain.Dtos
{
    public class ObjectiveResponse
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public string Title { get; set; }
        public string ProjectId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
