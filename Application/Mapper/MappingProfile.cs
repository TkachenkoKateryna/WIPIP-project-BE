using Domain.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Objective, ObjectiveResponse>();
            CreateMap<ObjectiveRequest, Objective>();

            CreateMap<EmployeeSkill, EmployeeSkillDto>()
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Skill.Title));
            CreateMap<Employee, EmployeeDto>()
                .IncludeAllDerived(); ;
        }

    }
}
