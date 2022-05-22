using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IObjectiveService
    {
        IEnumerable<ObjectiveResponse> GetAllObjectives();
        ObjectiveResponse AddObjective(ObjectiveRequest objDto);
        ObjectiveResponse UpdateObjective(ObjectiveRequest objDto, string objId);
        void DeleteObjective(string objId);
    }
}
