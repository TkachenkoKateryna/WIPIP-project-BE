using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface ISkillsService
    {
        IEnumerable<SkillResponse> GetSkills();
        SkillResponse AddSkill(SkillRequest skillRequest);
        SkillResponse UpdateSkill(SkillRequest skillRequest, Guid skillId);
        void DeleteSkill(Guid skillId);
    }
}
