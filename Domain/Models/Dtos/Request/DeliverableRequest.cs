
namespace Domain.Models.Dtos.Requests
{
    public class DeliverableRequest
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeOfComplition { get; set; }

    }
}
