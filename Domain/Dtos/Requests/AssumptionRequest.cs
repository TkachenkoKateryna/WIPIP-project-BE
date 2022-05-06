using Domain.Dtos.Base;

namespace Domain.Dtos.Requests
{
    public class AssumptionRequest : BaseRequest
    {
        public string Description { get; set; }
    }
}
