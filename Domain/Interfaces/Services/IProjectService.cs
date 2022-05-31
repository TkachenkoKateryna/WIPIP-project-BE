using Domain.Models.Constants;
using Domain.Models.Dtos.Project;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities.Identity;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        IEnumerable<ProjectsResponse> GetProjects(string managerId, IEnumerable<string> roles);
        ProjectResponse GetProjectById(string projId);
        ProjectResponse AddProject(ProjectRequest projectRequest);
        ProjectResponse UpdateProject(ProjectRequest projectRequest, string projectId);
        void DeleteProject(string projectId);
        ProjectResponse CalculateProjectBudget(string projectId);
        void SetProjectStatus(string projectId, ProjectStatus status);
    }
}
