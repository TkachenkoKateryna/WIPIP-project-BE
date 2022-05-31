using Domain.Models.Entities.Base;

namespace Domain.Models.Entities
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
