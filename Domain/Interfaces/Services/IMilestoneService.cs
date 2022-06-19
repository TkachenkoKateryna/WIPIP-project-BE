using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IMilestoneService
    {
        MilestoneResponse AddMilestone(MilestoneRequest mRequest);
        MilestoneResponse UpdateMilestone(MilestoneRequest mRequest, Guid mId);
        void DeleteMilestone(Guid mId);
    }
}
