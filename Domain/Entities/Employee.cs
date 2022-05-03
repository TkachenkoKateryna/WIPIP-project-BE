using Domain.Constants;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            EmployeeSkills = new List<EmployeeSkill>();
            Candidates = new List<ProjectCandidate>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DFD { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<ProjectCandidate> Candidates { get; set; }
    }
}
