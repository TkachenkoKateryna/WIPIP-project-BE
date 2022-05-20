using Domain.Constants;
using Domain.Dtos.Base;

namespace Domain.Dtos.Requests
{
    public class RiskRequest : BaseRequest
    {
        public string Title { get; set; }
        public Likelihood Likelihood { get; set; }
        public Impact Impact { get; set; }
        public string Mitigation { get; set; }
        public string RiskCategoryId { get; set; }
    }
}
