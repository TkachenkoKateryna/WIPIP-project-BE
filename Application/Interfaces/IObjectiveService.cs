using Domain.Dtos;

namespace Application.Interfaces
{
    public interface IObjectiveService
    {
        IEnumerable<ObjectiveResponse> GetAllObjectivesByProject(string projectId);
        IEnumerable<ObjectiveResponse> GetAllObjectives();
        ObjectiveResponse AddObjective(ObjectiveRequest objDto);
        ObjectiveResponse UpdateObjective(ObjectiveRequest objDto, string objId);
        void DeleteObjective(string objId);
    }
}
