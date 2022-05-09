using Domain.Dtos.Base;

namespace Domain.Dtos.Responses
{
    public class DeliverableResponse : BaseResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeOfComplition { get; set; }
    }
}
