using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface ICandidateService
    {
        IEnumerable<CandidateResponse> GetCandidates();
        CandidateResponse AddCandidate(CandidateRequest candRequest);
        CandidateResponse UpdateCandidate(CandidateRequest candRequest, string candId);
        CandidateResponse UpdateEmployeeToCandidate(CandidateEmployeeRequest candRequest);
        void DeleteCandidate(string candId);
    }
}
