using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Application.Interfaces
{
    public interface IStakeholdersService
    {
        IEnumerable<StakeholderResponse> GetAllStakeholders();
        IEnumerable<StakeholderResponse> GetAllStakeholdersByProject(string projectId);
        StakeholderResponse AddStakeholder(StakeholderRequest stRequest);
        StakeholderResponse UpdateStakeholder(StakeholderRequest stRequest, string stId);
        void DeleteStakeholder(StakeholderDeleteRequest stRequest);

    }
}
