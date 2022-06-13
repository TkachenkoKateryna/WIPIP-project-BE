
using Domain.Models.Constants;

namespace Domain.Models.Dtos.Responses
{
    public class ProjectResponse
    {
        public string Id { get; set; }
        public string IsDeleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double MonthlyIncome { get; set; }
        public double MonthlyOutcome { get; set; }
        public double MonthlyProfit { get; set; }
        public ProjectStatus Status { get; set; }
        public ManagerResponse Manager { get; set; }

        public List<AssumptionResponse> Assumptions { get; set; } = new List<AssumptionResponse>();
        public List<ObjectiveResponse> Objectives { get; set; } = new List<ObjectiveResponse>();
        public List<StakeholderResponse> Stakeholders { get; set; } = new List<StakeholderResponse>();
        public List<DeliverableResponse> Deliverables { get; set; } = new List<DeliverableResponse>();
        public List<MilestoneResponse> Milestones { get; set; } = new List<MilestoneResponse>();
        public List<RiskResponse> Risks { get; set; } = new List<RiskResponse>();
        public List<CandidateResponse> Candidates { get; set; } = new List<CandidateResponse>();
    }
}
