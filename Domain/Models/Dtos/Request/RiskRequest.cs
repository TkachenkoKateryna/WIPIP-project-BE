using Domain.Models.Constants;

namespace Domain.Models.Dtos.Requests
{
    public class RiskRequest
    {
        public string Title { get; set; }
        public Likelihood Likelihood { get; set; }
        public Impact Impact { get; set; }
        public string Mitigation { get; set; }
        public string RiskCategoryId { get; set; }
        public string ProjectId { get; set; }
    }
}
