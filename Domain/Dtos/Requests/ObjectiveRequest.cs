using Domain.Constants;

namespace Domain.Dtos
{
    public class ObjectiveRequest
    {
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public string Title { get; set; }
        public string ProjectId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
