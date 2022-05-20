using Domain.Constants;
using Domain.Dtos.Base;
using Domain.Entities;

namespace Domain.Dtos.Responses
{
    public class ProjectCandidateResponse : BaseResponse
    {
        public double FTE { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public int InternalRate { get; set; }
        public int ExternalRate { get; set; }
        public string Comment { get; set; }
        public SkillResponse Skill { get; set; }
        public Proficiency Proficiency { get; set; }
        public string EmployeeId { get; set; }
    }
}
