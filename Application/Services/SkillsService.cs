using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Skill> _skillRepository;

        public SkillsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _skillRepository = _uow.GetRepository<Skill>();
            _mapper = mapper;
        }

        public IEnumerable<SkillResponse> GetSkills()
        {
            return _skillRepository.GetAll().Select(entity =>
                    _mapper.Map<SkillResponse>(entity))
                .ToList();
        }
    }
}
