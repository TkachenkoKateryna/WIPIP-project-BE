using Domain.Constants;

namespace Domain.Dtos
{
    public class EmployeeSkillDto
    {
        public string Title { get; set; }
        public Proficiency Proficiency { get; set; }
        public bool Primary { get; set; }
    }
}
