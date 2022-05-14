using Domain.Constants;

namespace Domain.Dtos.Requests
{
    public class EmployeeSkillRequest
    {
        public string SkillId { get; set; }
        public Proficiency Proficiency { get; set; }
        public bool Primary { get; set; }

    }
}
