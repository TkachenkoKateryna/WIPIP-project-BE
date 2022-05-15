
using Domain.Constants;

namespace Domain.Dtos.Filters
{
    public class EmployeeFilteringParams
    {
        public string SearchBy { get; set; } = "";
        public string[] SkillIds { get; set; }
        public EnglishLevel? MinEnglishLevel { get; set; }
    }
}
