using Domain.Models.Constants;

namespace Domain.Models.Filters
{
    public class EmployeeFilteringParams
    {
        public string SearchBy { get; set; } = "";
        public Guid[] SkillIds { get; set; }
        public EnglishLevel? MinEnglishLevel { get; set; }
    }
}
