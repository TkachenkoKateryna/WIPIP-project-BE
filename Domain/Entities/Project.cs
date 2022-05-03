using Domain.Entities.Base;

namespace Domain.Entities
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

        public ICollection<ProjectStakeholder> ProjectStakeholders { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
        public ICollection<Deliverable> Deliverables { get; set; }
        public ICollection<Assumption> Assumptions { get; set; }
        public ICollection<Objective> Objectives { get; set; }
        public ICollection<ProjectCandidate> Candidates { get; set; }
        public ICollection<ProjectRisk> ProjectRisks { get; set; }
    }
}
