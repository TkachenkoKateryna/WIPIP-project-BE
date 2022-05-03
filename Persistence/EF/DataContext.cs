using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Persistence.EF
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Assumption> Assumptions { get; set; }
        public DbSet<Deliverable> Deliverables { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCandidate> ProjectCandidates { get; set; }
        public DbSet<ProjectRisk> ProjectRisks { get; set; }
        public DbSet<ProjectStakeholder> ProjectStakeholders { get; set; }
        public DbSet<Risk> Risks { get; set; }
        public DbSet<RiskCategory> RiskCategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Stakeholder> Stakeholders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
