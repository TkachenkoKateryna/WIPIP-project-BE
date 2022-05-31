using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Stakeholder;

namespace Domain.Interfaces.Services
{
    public interface IStakeholdersService
    {
        IEnumerable<StakeholderResponse> GetStakeholders(string managerId, IEnumerable<string> roles);
        IEnumerable<StakeholderResponse> GetStakeholders(string projectId);
        StakeholderResponse AddStakeholder(StakeholderRequest stRequest);
        StakeholderResponse AddStakeholderToProject(StakeholderProjectRequest projStakeholderRequest);
        StakeholderResponse UpdateStakeholder(StakeholderRequest stRequest, string stId);
        void DeleteStakeholder(StakeholderProjectRequest stRequest);

    }
}
