namespace Domain.Models.Dtos.Requests
{
    public class MilestoneRequest
    {
        public string ProjectId { get; set; }
        public string Activity { get; set; }
        public DateTime DueDate { get; set; }
        public List<string> DeliverablesId { get; set; }
    }
}
