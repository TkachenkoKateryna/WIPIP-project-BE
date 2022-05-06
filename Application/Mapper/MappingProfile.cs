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

            CreateMap<EmployeeSkill, EmployeeSkillDto>()
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Skill.Title));

            CreateMap<Employee, EmployeeDto>()
                .IncludeAllDerived(); ;
        }

    }
}
