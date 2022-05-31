using Domain.Constants;

namespace Domain.Dtos
{
    public class EmployeeDto
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DFD { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public List<EmployeeSkillDto> EmployeeSkills { get; set; }
    }
}
