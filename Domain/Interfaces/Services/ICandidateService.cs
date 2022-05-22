using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface ICandidateService
    {
        IEnumerable<ProjectCandidateResponse> GetCandidates();
        ProjectCandidateResponse AddCandidate(ProjectCandidateRequest candRequest);
        ProjectCandidateResponse UpdateCandidate(ProjectCandidateRequest candRequest, string candId);
        void DeleteCandidate(string candId);
    }
}
