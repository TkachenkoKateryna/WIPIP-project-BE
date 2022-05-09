using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Application.Interfaces
{
    public interface IMilestoneService
    {
        IEnumerable<MilestoneResponse> GetAllMilestonesByProject(string projectId);
        IEnumerable<MilestoneResponse> GetAllMilestones();
        MilestoneResponse AddMilestone(MilestoneRequest milRequest);
        MilestoneResponse UpdateMilestone(MilestoneRequest milRequest, string milId);
        void DeleteMilestone(string milId);
    }
}
