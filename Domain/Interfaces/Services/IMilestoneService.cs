using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IMilestoneService
    {
        IEnumerable<MilestoneResponse> GetAllMilestones();
        MilestoneResponse AddMilestone(MilestoneRequest milRequest);
        MilestoneResponse UpdateMilestone(MilestoneRequest milRequest, string milId);
        void DeleteMilestone(string milId);
    }
}
