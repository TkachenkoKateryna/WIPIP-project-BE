using AutoMapper;
using Domain.Models.Dtos.Project;
using Domain.Models.Entities;
using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Stakeholder;
using Domain.Models.Entities.Identity;
using Domain.Models.Dtos.Response;
using Domain.Models.Dtos.Request;

namespace Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Objective, ObjectiveResponse>();
            CreateMap<ObjectiveRequest, Objective>();

            CreateMap<Assumption, AssumptionResponse>();
            CreateMap<AssumptionRequest, Assumption>();

            CreateMap<Deliverable, DeliverableResponse>();
            CreateMap<DeliverableRequest, Deliverable>();

            CreateMap<Milestone, MilestoneResponse>();
            CreateMap<MilestoneRequest, Milestone>()
                .IncludeAllDerived();

            CreateMap<ProjectStakeholder, StakeholderResponse>()
                .ForMember(m => m.Id, opt => opt.MapFrom(m => m.Stakeholder.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(m => m.Stakeholder.Name))
                .ForMember(m => m.Email, opt => opt.MapFrom(m => m.Stakeholder.Email))
                .ForMember(m => m.Address, opt => opt.MapFrom(m => m.Stakeholder.Address))
                .ForMember(m => m.Notes, opt => opt.MapFrom(m => m.Stakeholder.Notes))
                .ForMember(m => m.Payment, opt => opt.MapFrom(m => m.Stakeholder.Payment))
                .ForMember(m => m.Class, opt => opt.MapFrom(m => m.Stakeholder.Class))
                .ForMember(m => m.Interest, opt => opt.MapFrom(m => m.Stakeholder.Interest))
                .ForMember(m => m.Influence, opt => opt.MapFrom(m => m.Stakeholder.Influence))
                .ForMember(m => m.ImageLink, opt => opt.MapFrom(m => m.Stakeholder.ImageLink))
                .ForMember(m => m.IsDeleted, opt => opt.MapFrom(m => m.Stakeholder.IsDeleted));
            CreateMap<Stakeholder, StakeholderResponse>();
            CreateMap<ProjectStakeholder, ProjectStakeholderResponse>()
                .ForMember(m => m.Id, opt => opt.MapFrom(m => m.ProjectId))
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Project.Title));
            CreateMap<StakeholderRequest, Stakeholder>();

            CreateMap<Skill, SkillResponse>();
            CreateMap<SkillRequest, Skill>();

            CreateMap<EmployeeSkill, EmployeeSkillResponse>()
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Skill.Title));
            CreateMap<EmployeeSkillRequest, EmployeeSkill>();
            CreateMap<Employee, EmployeeResponse>()
                .IncludeAllDerived();
            CreateMap<EmployeeRequest, Employee>()
                .ForMember(m => m.EmployeeSkills, opt => opt.Ignore());

            CreateMap<Employee, CandidateEmployeeResponse>();
            CreateMap<ProjectCandidate, CandidateResponse>();
            CreateMap<CandidateRequest, ProjectCandidate>()
                .ForMember(c => c.EmployeeId, opt => opt.UseDestinationValue());

            CreateMap<RiskCategory, RiskCategoryResponse>()
              .ForMember(m => m.Id, opt => opt.MapFrom(r => r.Id))
              .ForMember(m => m.Title, opt => opt.MapFrom(r => r.Title));

            CreateMap<RiskCategoryRequest, RiskCategory>();

            CreateMap<ProjectRisk, ProjectRiskResponse>();
            CreateMap<ProjectRisk, RiskResponse>()
                .ForMember(m => m.Id, opt => opt.MapFrom(m => m.RiskId))
                .ForMember(m => m.Impact, opt => opt.MapFrom(m => m.Risk.Impact))
                .ForMember(m => m.Likelihood, opt => opt.MapFrom(m => m.Risk.Likelihood))
                .ForMember(m => m.Mitigation, opt => opt.MapFrom(m => m.Risk.Mitigation))
                .ForPath(m => m.RiskCategory.Id, opt => opt.MapFrom(m => m.Risk.RiskCategory.Id))
                .ForPath(m => m.RiskCategory.Title, opt => opt.MapFrom(m => m.Risk.RiskCategory.Title))
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Risk.Title))
                .ForMember(m => m.IsDeleted, opt => opt.MapFrom(m => m.Risk.IsDeleted))
                .ForMember(m => m.Description, opt => opt.MapFrom(m => m.Risk.Description))
                .ForMember(m => m.Consequence, opt => opt.MapFrom(m => m.Risk.Consequence))
                .ForMember(m => m.Level, opt => opt.MapFrom(r => (int)r.Risk.Impact * (int)r.Risk.Likelihood));

            CreateMap<Risk, RiskResponse>()
                .ForMember(m => m.Level, opt => opt.MapFrom(r => (int)r.Impact * (int)r.Likelihood))
                .ForPath(r => r.RiskCategory.Id, opt => opt.MapFrom(r => r.RiskCategory.Id))
                .ForPath(r => r.RiskCategory.Title, opt => opt.MapFrom(r => r.RiskCategory.Title));

            CreateMap<RiskRequest, Risk>()
                .ForMember(m => m.Consequence, opt => opt.MapFrom(r => r.Consequence));


            CreateMap<User, ManagerResponse>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.UserName));

            CreateMap<Project, ProjectsResponse>()
                .ForPath(p => p.Manager.Id, opt => opt.MapFrom(p => p.ManagerId))
                .ForPath(p => p.Manager.Name, opt => opt.MapFrom(p => p.Manager.UserName))
                .ForPath(p => p.Manager.Role, opt => opt.MapFrom(p => p.Manager.Role));

            CreateMap<Project, ProjectResponse>();
            CreateMap<ProjectRequest, Project>()
                .ForMember(p => p.ManagerId, opt => opt.MapFrom(p => p.ManagerId));

        }

    }
}
