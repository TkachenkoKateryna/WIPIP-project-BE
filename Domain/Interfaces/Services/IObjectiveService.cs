using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IObjectiveService
    {
        IEnumerable<ObjectiveResponse> GetAllObjectives();
        ObjectiveResponse AddObjective(ObjectiveRequest objDto);
        ObjectiveResponse UpdateObjective(ObjectiveRequest objDto, Guid objId);
        void DeleteObjective(string objId);
    }
}
