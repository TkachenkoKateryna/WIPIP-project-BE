using Domain.Models.Constants;
using Domain.Models.Dtos.Project;
using Domain.Models.Dtos.Responses;
using Domain.Models.Filters;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        IEnumerable<ProjectsResponse> GetProjects(string managerId, string role, ProjectFilteringParams param = null);
        ProjectResponse GetProjectById(Guid projId);
        ProjectResponse AddProject(ProjectRequest projectRequest);
        ProjectResponse UpdateProject(ProjectRequest projectRequest, Guid projectId);
        void DeleteProject(Guid projectId);
        ProjectResponse CalculateProjectBudget(Guid projectId);
        void SetProjectStatus(Guid projectId, ProjectStatus status);
    }
}
