using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IRiskService
    {
        IEnumerable<RiskResponse> GetAllRisks();
        IEnumerable<RiskResponse> GetRisksByProject(string projectId);
        RiskResponse AddRisk(RiskRequest riskRequest);
        RiskResponse UpdateRisk(RiskRequest riskRequest, string riskId);
        void DeleteRisk(string riskId);
        RiskResponse RemoveRiskFromProject(string projectId, string riskId);
        RiskResponse AssignRiskToProject(string projectId, string riskId);
        IEnumerable<RiskCategoryResponse> GetRiskCategories();
        IEnumerable<RiskResponse> GenerateRisks(string projectId);
    }
}
