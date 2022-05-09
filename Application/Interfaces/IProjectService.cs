using Domain.Dtos.Responses;

namespace Application.Interfaces
{
    public interface IProjectService
    {
        ProjectResponse GetProjectById(string projId);
    }
}
