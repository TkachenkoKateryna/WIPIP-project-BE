using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IRiskService
    {
        IEnumerable<RiskResponse> GetRisks();
        IEnumerable<RiskResponse> GetRisksByProject(Guid prId);
        RiskResponse AddRisk(RiskRequest rRequest);
        RiskResponse AssignRiskToProject(Guid prId, Guid rId);
        RiskResponse UpdateRisk(RiskRequest rRequest, Guid rId);
        void DeleteRisk(Guid riskId);
        RiskResponse RemoveRiskFromProject(Guid prId, Guid rId);
        IEnumerable<RiskResponse> GenerateRisks(Guid prId);
    }
}
