using Domain.Models.Constants;
using Domain.Models.Dtos.Response;

namespace Domain.Models.Dtos.Responses
{
    public class CandidateResponse
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public double FTE { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public int InternalRate { get; set; }
        public int ExternalRate { get; set; }
        public string Comment { get; set; }
        public SkillResponse Skill { get; set; }
        public Proficiency Proficiency { get; set; }
        public CandidateEmployeeResponse Employee { get; set; }
        public string ProjectId { get; set; }
    }
}
