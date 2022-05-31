using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IAssumptionsService
    {
        IEnumerable<AssumptionResponse> GetAssumptions(string projId = null);
        AssumptionResponse AddAssumption(AssumptionRequest assumpRequest);
        AssumptionResponse UpdateAssumption(AssumptionRequest assumpRequest, string assumpId);
        void DeleteAssumption(string assumpId);

    }
}
