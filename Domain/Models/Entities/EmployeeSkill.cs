using Domain.Models.Constants;
using Domain.Models.Entities.Base;

namespace Domain.Models.Entities
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
