using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Application.Interfaces
{
    public interface IRiskService
    {
        IEnumerable<RiskResponse> GetAllRisks();
        IEnumerable<RiskResponse> GetRisksByProject(string projectId);
        RiskResponse AddRisk(RiskRequest riskRequest);
        RiskResponse UpdateRisk(RiskRequest riskRequest, string riskId);
        void DeleteRisk(string riskId);
    }
}
