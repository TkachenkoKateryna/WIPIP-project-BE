using Domain.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface ISkillsService
    {
        IEnumerable<SkillResponse> GetSkills();
    }
}
