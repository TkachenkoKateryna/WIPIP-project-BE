using Domain.Constants;

namespace Domain.Dtos.Responses
{
    public class EmployeeSkillResponse
    {
        public string SkillId { get; set; }
        public string Title { get; set; }
        public Proficiency Proficiency { get; set; }
        public bool Primary { get; set; }
    }
}
