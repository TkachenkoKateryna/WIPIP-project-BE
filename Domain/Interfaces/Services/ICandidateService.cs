using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface ICandidateService
    {
        IEnumerable<EmployeeResponse> GetEmployeesForCandidates(Guid projectId);
        CandidateResponse AddCandidate(CandidateRequest candRequest);
        CandidateResponse UpdateCandidate(CandidateRequest candRequest, Guid candId);
        CandidateResponse UpdateEmployeeToCandidate(CandidateEmployeeRequest candRequest);
        void DeleteCandidate(Guid candId);
    }
}
