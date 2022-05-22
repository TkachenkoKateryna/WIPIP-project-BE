using Domain.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        ProjectResponse GetProjectById(string projId);
        ProjectBudgetResponse CalculateProjectBudget(string projectId);
    }
}
