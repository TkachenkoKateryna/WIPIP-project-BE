using Domain.Constants;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Risk : BaseEntity
    {
        public Risk()
        {
            ProjectRisks = new List<ProjectRisk>();
        }

        public string Title { get; set; }
        public Likelihood Likelihood { get; set; }
        public Impact Impact { get; set; }
        public string Mitigation { get; set; }

        public Guid RiskCategoryId { get; set; }
        public RiskCategory RiskCategory { get; set; }
        public ICollection<ProjectRisk> ProjectRisks { get; set; }
    }
}
