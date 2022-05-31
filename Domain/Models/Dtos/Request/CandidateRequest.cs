using Domain.Models.Constants;

namespace Domain.Models.Dtos.Requests
{
    public class CandidateRequest
    {
        public string ProjectId { get; set; }
        public double FTE { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public int InternalRate { get; set; }
        public int ExternalRate { get; set; }
        public string Comment { get; set; }
        public string SkillId { get; set; }
        public Proficiency Proficiency { get; set; }
        public string EmployeeId { get; set; }
    }
}
