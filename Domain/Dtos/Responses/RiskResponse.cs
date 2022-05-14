using Domain.Constants;

namespace Domain.Dtos.Responses
{
    public class RiskResponse
    {
        public string Title { get; set; }
        public Likelihood Likelihood { get; set; }
        public Impact Impact { get; set; }
        public string Mitigation { get; set; }

        public string CategoryId { get; set; }

        public string CategotyTitle { get; set; }
    }
}
