using Domain.Models.Constants;
using Domain.Models.Dtos.Project;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities.Identity;
using Domain.Models.Filters;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        IEnumerable<ProjectsResponse> GetProjects(string managerId, string role, ProjectFilteringParams param = null);
        ProjectResponse GetProjectById(string projId);
        ProjectResponse AddProject(ProjectRequest projectRequest);
        ProjectResponse UpdateProject(ProjectRequest projectRequest, string projectId);
        void DeleteProject(string projectId);
        ProjectResponse CalculateProjectBudget(string projectId);
        void SetProjectStatus(string projectId, ProjectStatus status);
    }
}
