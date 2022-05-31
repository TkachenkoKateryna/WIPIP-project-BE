﻿using AutoMapper;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
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
