using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Skill : BaseEntity
    {
        public Skill()
        {
            EmployeeSkills = new List<EmployeeSkill>();
            Candidates = new List<ProjectCandidate>();
        }

        public string Title { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<ProjectCandidate> Candidates { get; set; }
    }
}
