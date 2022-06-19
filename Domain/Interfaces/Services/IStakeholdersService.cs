using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Stakeholder;
using Domain.Models.Filters;

namespace Domain.Interfaces.Services
{
    public interface IStakeholdersService
    {
        IEnumerable<StakeholderResponse> GetStakeholders(StakeholderFiteringParam param = null);
        IEnumerable<StakeholderResponse> GetStakeholders(Guid prId);
        StakeholderResponse AddStakeholder(StakeholderRequest stRequest);
        StakeholderResponse AddStakeholderToProject(Guid prId, Guid stId);
        StakeholderResponse UpdateStakeholder(StakeholderRequest stRequest, Guid stId);
        void DeleteStakeholder(Guid stakeholderId);
        StakeholderResponse RemoveStakeholderFromProject(Guid prId, Guid stId);
    }
}
