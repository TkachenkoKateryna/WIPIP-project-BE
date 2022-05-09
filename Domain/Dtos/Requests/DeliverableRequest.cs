using Domain.Dtos.Base;

namespace Domain.Dtos.Requests
{
    public class DeliverableRequest : BaseRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeOfComplition { get; set; }

    }
}
