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
            return _skillRepository.GetAll().Select(sk => _mapper.Map<SkillResponse>(sk)).ToList();
        }

        public SkillResponse AddSkill(SkillRequest skRequest)
        {

            var skEntity = _skillRepository.Find(sk => sk.Title == skRequest.Title).FirstOrDefault();

            if (skEntity != null)
            {
                throw new AlreadyExistsException("Skill with such title already exists", "title");
            }

            skEntity = _mapper.Map<Skill>(skRequest);

            var id = _skillRepository.CreateWithVal(skEntity);
            _uow.Save();

            return _mapper.Map<SkillResponse>(_skillRepository.Find(sk => sk.Id == id).FirstOrDefault());
        }

        public SkillResponse UpdateSkill(SkillRequest skRequest, Guid skId)
        {
            var skEntity = _skillRepository.Find(sk => sk.Id == skId).FirstOrDefault();

            _ = skEntity ?? throw new NotFoundException("Skill was not found");

            skEntity = _mapper.Map<Skill>(skRequest);
            skEntity.Id = skId;

            _skillRepository.Update(skEntity);
            _uow.Save();


            return _mapper.Map<SkillResponse>(_skillRepository.Find(sk => sk.Id == skId).FirstOrDefault());
        }

        public void DeleteSkill(Guid skId)
        {
            var skEntity = _skillRepository.Find(sk => sk.Id == skId).FirstOrDefault();

            _ = skEntity ?? throw new NotFoundException("Skill was not found");

            _skillRepository.SoftDelete(skId);
            _uow.Save();
        }
    }
}
