using Domain.Models.Constants;
using Domain.Models.Entities.Base;

namespace Domain.Models.Entities
{
    public class Risk : BaseEntity
    {
        public Risk()
        {
            ProjectRisks = new List<ProjectRisk>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Consequence { get; set; }
        public Likelihood Likelihood { get; set; }
        public Impact Impact { get; set; }
        public string Mitigation { get; set; }
        public Guid RiskCategoryId { get; set; }
        public RiskCategory RiskCategory { get; set; }
        public ICollection<ProjectRisk> ProjectRisks { get; set; }
    }
}
