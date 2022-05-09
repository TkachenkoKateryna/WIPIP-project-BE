using Domain.Dtos.Base;

namespace Domain.Dtos.Responses
{
    public class MilestoneResponse : BaseResponse
    {
        public string Activity { get; set; }
        public DateTime DueTime { get; set; }
        public List<DeliverableResponse> Deliverables { get; set; }
    }
}
