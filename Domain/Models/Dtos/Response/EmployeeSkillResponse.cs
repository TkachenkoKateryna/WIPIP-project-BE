using Domain.Models.Constants;

namespace Domain.Models.Dtos.Responses
{
    public class EmployeeSkillResponse
    {
        public string SkillId { get; set; }
        public string Title { get; set; }
        public Proficiency Proficiency { get; set; }
        public bool Primary { get; set; }
    }
}
