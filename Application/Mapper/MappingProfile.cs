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

            CreateMap<Project, ProjectResponse>()
                .IncludeAllDerived();

            CreateMap<EmployeeSkill, EmployeeSkillResponse>()
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Skill.Title));

            CreateMap<EmployeeSkillRequest, EmployeeSkill>();

            CreateMap<Employee, EmployeeResponse>()
                .IncludeAllDerived();


            CreateMap<EmployeeRequest, Employee>()
                .ForMember(m => m.EmployeeSkills, opt => opt.Ignore());

            CreateMap<Project, ProjectResponse>();
        }

    }
}
