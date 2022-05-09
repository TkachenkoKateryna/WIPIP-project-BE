using Domain.Dtos.Base;
using Domain.Dtos.Responses;

namespace Domain.Dtos.Responses
{
    public class ProjectResponse : BaseResponse
    {
        public string Description { get; set; }
        public List<AssumptionResponse> Assumptions { get; set; }
        public List<ObjectiveResponse> Objectives { get; set; }
        public List<StakeholderResponse> Stakeholders { get; set; }
    }
}
