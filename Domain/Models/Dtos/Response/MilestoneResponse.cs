
namespace Domain.Models.Dtos.Responses
{
    public class MilestoneResponse
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Activity { get; set; }
        public DateTime DueDate { get; set; }
        public string ProjectId { get; set; }
        public List<DeliverableResponse> Deliverables { get; set; }
    }
}
