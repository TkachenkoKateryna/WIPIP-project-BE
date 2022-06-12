using AutoMapper;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Dtos.Request;
using Domain.Models.Exceptions;

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

        public SkillResponse AddSkill(SkillRequest skillRequest)
        {

            var skillEntity = _skillRepository.Find(skill => skill.Title == skillRequest.Title)
                .FirstOrDefault();

            if (skillEntity != null)
            {
                throw new AlreadyExistsException<Skill>("Assumption with such description already exists.");
            }

            skillEntity = _mapper.Map<Skill>(skillRequest);

            var id = _skillRepository.CreateWithVal(skillEntity);
            _uow.Save();

            return _mapper.Map<SkillResponse>(_skillRepository.Find(skill => skill.Id == id).FirstOrDefault());
        }

        public SkillResponse UpdateSkill(SkillRequest skillRequest, Guid skillId)
        {
            var skillEntity = _skillRepository.Find(skill => skill.Id == skillId)
                .FirstOrDefault();
            _ = skillEntity ?? throw new NotFoundException<Skill>("Assumption with id was not found.");

            skillEntity = _mapper.Map<Skill>(skillRequest);
            skillEntity.Id = skillId;

            _skillRepository.Update(skillEntity);
            _uow.Save();


            return _mapper.Map<SkillResponse>(_skillRepository.Find(skill => skill.Id == skillId).FirstOrDefault());
        }

        public void DeleteSkill(Guid skillId)
        {
            var skillEntity = _skillRepository.Find(skill => skill.Id == skillId)
                .FirstOrDefault();
            _ = skillEntity ?? throw new NotFoundException<Skill>("Assumption with id was not found.");

            _skillRepository.SoftDelete(skillId);
            _uow.Save();
        }
    }
}
