using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Application.Interfaces
{
    public interface IRiskService
    {
        IEnumerable<RiskResponse> GetAllRisksByProject(string projectId);
        IEnumerable<RiskResponse> GetAllRisks();
        RiskResponse AddRisk(RiskRequest riskRequest);
        RiskResponse UpdateRisk(RiskRequest riskRequest, string riskId);
        void DeleteRisk(string riskId);
    }
}
