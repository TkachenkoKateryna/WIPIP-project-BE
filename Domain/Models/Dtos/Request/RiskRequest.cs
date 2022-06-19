using Domain.Models.Constants;

namespace Domain.Models.Dtos.Requests
{
    public class RiskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Consequence { get; set; }
        public Likelihood Likelihood { get; set; }
        public Impact Impact { get; set; }
        public string Mitigation { get; set; }
        public Guid RiskCategoryId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
