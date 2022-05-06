using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Application.Interfaces
{
    public interface IAssumptionsService
    {
        IEnumerable<AssumptionResponse> GetAllAssumptions();
        IEnumerable<AssumptionResponse> GetAllAssumptionsByProject(string projectId);
        AssumptionResponse AddAssumption(AssumptionRequest assumpRequest);
        AssumptionResponse UpdateAssumption(AssumptionRequest assumpRequest, string assumpId);
        void DeleteAssumption(string assumpId);

    }
}
