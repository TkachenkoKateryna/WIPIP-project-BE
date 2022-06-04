using Domain.Models.Constants;

namespace Domain.Models.Dtos.Responses
{
    public class RiskResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Consequence { get; set; }
        public Likelihood Likelihood { get; set; }
        public Impact Impact { get; set; }
        public int Level { get; set; }
        public string Mitigation { get; set; }
        public RiskCategoryResponse RiskCategory { get; set; }
        public List<ProjectRiskResponse> ProjectRisks { get; set; } = new List<ProjectRiskResponse>();
        public bool IsDeleted { get; set; }
    }
}
