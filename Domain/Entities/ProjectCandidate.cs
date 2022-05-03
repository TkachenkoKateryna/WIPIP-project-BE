using Domain.Constants;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class ProjectCandidate : BaseEntity
    {
        public string Title { get; set; }
        public double Experience { get; set; }
        public double FTE { get; set; }
        public EnglishLevel EnglishLevel{ get; set; }
        public int InternalRate { get; set; }
        public int ExternalRate { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }    

    }
}
