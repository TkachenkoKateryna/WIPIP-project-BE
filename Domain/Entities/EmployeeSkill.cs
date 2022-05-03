using Domain.Constants;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class EmployeeSkill : BaseEntity
    {
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Proficiency Proficiency { get; set; }

        public bool Primary { get; set; }
    }
}
