using Domain.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Dtos.Responses;
using Domain.Dtos.Requests;

namespace Application.Mapper
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
                .ForMember(m => m.Engagement, opt => opt.MapFrom(m => m.Stakeholder.Engagement))
                .ForMember(m => m.Class, opt => opt.MapFrom(m => m.Stakeholder.Class))
                .ForMember(m => m.IsDeleted, opt => opt.MapFrom(m => m.Stakeholder.IsDeleted));
            CreateMap<Stakeholder, StakeholderResponse>();
            CreateMap<StakeholderRequest, Stakeholder>();

            CreateMap<Skill, SkillResponse>();

            CreateMap<EmployeeSkill, EmployeeSkillResponse>()
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Skill.Title));
            CreateMap<EmployeeSkillRequest, EmployeeSkill>();
            CreateMap<Employee, EmployeeResponse>()
                .IncludeAllDerived();
            CreateMap<EmployeeRequest, Employee>()
                .ForMember(m => m.EmployeeSkills, opt => opt.Ignore());

            CreateMap<ProjectCandidate, ProjectCandidateResponse>();
            CreateMap<ProjectCandidateRequest, ProjectCandidate>();

            CreateMap<ProjectRisk, ProjectRiskResponse>();
            CreateMap<ProjectRisk, RiskResponse>()
                .ForMember(m => m.Id, opt => opt.MapFrom(m => m.RiskId))
                .ForMember(m => m.Impact, opt => opt.MapFrom(m => m.Risk.Impact))
                .ForMember(m => m.Likelihood, opt => opt.MapFrom(m => m.Risk.Likelihood))
                .ForMember(m => m.Mitigation, opt => opt.MapFrom(m => m.Risk.Mitigation))
                .ForMember(m => m.RiskCategoryId, opt => opt.MapFrom(m => m.Risk.RiskCategoryId))
                .ForMember(m => m.RiskCategotyTitle, opt => opt.MapFrom(m => m.Risk.RiskCategory.Title))
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Risk.Title))
                .ForMember(m => m.IsDeleted, opt => opt.MapFrom(m => m.Risk.IsDeleted))
                .ForMember(m => m.Level, opt => opt.MapFrom(r => (int)r.Risk.Impact * (int)r.Risk.Likelihood));
            CreateMap<Risk, RiskResponse>()
                .ForMember(m => m.Level, opt => opt.MapFrom(r => (int)r.Impact * (int)r.Likelihood))
                .ForMember(r => r.RiskCategotyTitle, opt => opt.MapFrom(r => r.RiskCategory.Title));
            CreateMap<RiskRequest, Risk>();

            CreateMap<Project, ProjectResponse>()
                .IncludeAllDerived();
        }

    }
}
