using Domain.Dtos.Base;
using Domain.Dtos.Responses;

namespace Domain.Dtos.Responses
{
    public class ProjectResponse : BaseResponse
    {
        public string Description { get; set; }
        public List<AssumptionResponse> Assumptions { get; set; } = new List<AssumptionResponse>();
        public List<ObjectiveResponse> Objectives { get; set; } = new List<ObjectiveResponse>();
        public List<StakeholderResponse> Stakeholders { get; set; } = new List<StakeholderResponse>();
        public List<DeliverableResponse> Deliverables { get; set; } = new List<DeliverableResponse>();
        public List<MilestoneResponse> Milestones { get; set; } = new List<MilestoneResponse>();
        public List<RiskResponse> Risks { get; set; } = new List<RiskResponse>();
        public List<ProjectCandidateResponse> Candidates { get; set; } = new List<ProjectCandidateResponse>();
    }
}
