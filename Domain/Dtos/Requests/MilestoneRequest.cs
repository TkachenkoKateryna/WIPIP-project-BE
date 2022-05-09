using Domain.Dtos.Base;

namespace Domain.Dtos.Requests
{
    public class MilestoneRequest : BaseRequest
    {
        public string Activity { get; set; }
        public DateTime DueDate { get; set; }
        public List<string> DeliverablesId { get; set; }
    }
}
