namespace Domain.Models.Dtos.Requests
{
    public class MilestoneRequest
    {
        public Guid ProjectId { get; set; }
        public string Activity { get; set; }
        public DateTime DueDate { get; set; }
        public List<Guid> DeliverablesId { get; set; }
    }
}
