using Domain.Entities.Base;

namespace Domain.Entities
{
    public class RiskCategory: BaseEntity
    {
        public RiskCategory()
        {
            Risks = new List<Risk>();
        }
        public string Title { get; set; }

        public ICollection<Risk> Risks { get; set; }
    }
}
