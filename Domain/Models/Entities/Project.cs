using Domain.Models.Constants;
using Domain.Models.Entities.Base;
using Domain.Models.Entities.Identity;

namespace Domain.Models.Entities
{
    public class Project : BaseEntity
    {
        public Project()
        {
            ProjectStakeholders = new List<ProjectStakeholder>();
            Milestones = new List<Milestone>();
            Deliverables = new List<Deliverable>();
            ProjectRisks = new List<ProjectRisk>();
            Assumptions = new List<Assumption>();
            Objectives = new List<Objective>();
            Candidates = new List<ProjectCandidate>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public double MonthlyIncome { get; set; }
        public double MonthlyOutcome { get; set; }
        public double MonthlyProfit { get; set; }
        public ProjectStatus Status { get; set; }
        public string ManagerId { get; set; }
        public User Manager { get; set; }
        public ICollection<ProjectStakeholder> ProjectStakeholders { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
        public ICollection<Deliverable> Deliverables { get; set; }
        public ICollection<Assumption> Assumptions { get; set; }
        public ICollection<Objective> Objectives { get; set; }
        public ICollection<ProjectCandidate> Candidates { get; set; }
        public ICollection<ProjectRisk> ProjectRisks { get; set; }
    }
}
