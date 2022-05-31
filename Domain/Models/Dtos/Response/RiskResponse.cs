using Domain.Models.Constants;

namespace Domain.Models.Dtos.Responses
{
    public class RiskResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Likelihood Likelihood { get; set; }
        public Impact Impact { get; set; }
        public int Level { get; set; }
        public string Mitigation { get; set; }
        public string RiskCategoryId { get; set; }
        public string RiskCategotyTitle { get; set; }
        public List<ProjectRiskResponse> ProjectRisks { get; set; } = new List<ProjectRiskResponse>();
        public bool IsDeleted { get; set; }
    }
}
