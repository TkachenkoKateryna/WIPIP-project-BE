using Domain.Models.Constants;

namespace Domain.Models.Dtos.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DFD { get; set; }
        public string Specialization { get; set; }
        public string ImageLink { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public List<EmployeeSkillRequest> EmployeeSkills { get; set; }
    }
}
