using Domain.Models.Constants;

namespace Domain.Models.Dtos.Requests
{
    public class EmployeeSkillRequest
    {
        public Guid SkillId { get; set; }
        public Proficiency Proficiency { get; set; }
        public bool Primary { get; set; }

    }
}
