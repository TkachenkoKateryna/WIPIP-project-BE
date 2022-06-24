using AutoMapper;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Dtos.Request;
using Domain.Models.Exceptions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Skill> _skillRepository;
        private readonly Func<IQueryable<Skill>, IIncludableQueryable<Skill, object>> _includes;
        public SkillsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _skillRepository = _uow.GetRepository<Skill>();
            _mapper = mapper;
            _includes = skill => skill
                .Include(s => s.EmployeeSkills)
                .Include(s => s.Candidates);
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
            var skEntity = _skillRepository.Find(sk => sk.Id == skId, _includes).FirstOrDefault();

            _ = skEntity ?? throw new NotFoundException("Skill was not found");

            if (skEntity.Candidates.Count != 0 || skEntity.EmployeeSkills.Count != 0)
            {
                throw new AlreadyExistsException("Skill has been already assigned to other elements. To delete the skill reassign it from elements.");
            }

            _skillRepository.SoftDelete(skId);
            _uow.Save();
        }
    }
}
