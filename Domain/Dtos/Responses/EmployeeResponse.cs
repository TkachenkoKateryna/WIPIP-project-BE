using Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Domain.Dtos.Responses
{
    public class EmployeeResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DFD { get; set; }
        public string Specialization { get; set; }
        public string ImageLink { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public List<EmployeeSkillResponse> EmployeeSkills { get; set; }
    }
}
