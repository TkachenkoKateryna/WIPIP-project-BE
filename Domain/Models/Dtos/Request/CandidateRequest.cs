using Domain.Models.Constants;

namespace Domain.Models.Dtos.Requests
{
    public class CandidateRequest
    {
        public Guid ProjectId { get; set; }
        public double FTE { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public int InternalRate { get; set; }
        public int ExternalRate { get; set; }
        public string Comment { get; set; }
        public Guid SkillId { get; set; }
        public Proficiency Proficiency { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
