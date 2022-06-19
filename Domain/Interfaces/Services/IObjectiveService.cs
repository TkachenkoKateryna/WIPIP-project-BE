using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IObjectiveService
    {
        ObjectiveResponse AddObjective(ObjectiveRequest obRequest);
        ObjectiveResponse UpdateObjective(ObjectiveRequest obRequest, Guid obId);
        void DeleteObjective(Guid obId);
    }
}
