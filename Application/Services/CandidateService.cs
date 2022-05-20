using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<ProjectCandidate> _candidateRepository;
        private readonly Func<IQueryable<ProjectCandidate>, IIncludableQueryable<ProjectCandidate, object>> _includes;

        public CandidateService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _candidateRepository = _uow.GetRepository<ProjectCandidate>();
            _mapper = mapper;
            _includes = candidate => candidate
                .Include(c => c.Project)
                .Include(c => c.Employee)
                .Include(c => c.Skill);
        }

        public IEnumerable<ProjectCandidateResponse> GetCandidates()
        {
            return _candidateRepository.GetAllWithDeleted(_includes)
                .Select(c => _mapper.Map<ProjectCandidateResponse>(c))
                .ToList();
        }

        public ProjectCandidateResponse AddCandidate(ProjectCandidateRequest candRequest)
        {
            var candEntity = _mapper.Map<ProjectCandidate>(candRequest);
            var id = _candidateRepository.CreateWithVal(candEntity);
            _uow.Save();

            return _mapper.Map<ProjectCandidateResponse>(_candidateRepository
                    .Find(cand => cand.Id == id, _includes)
                    .FirstOrDefault());
        }

        public ProjectCandidateResponse UpdateCandidate(ProjectCandidateRequest candidateRequest, string candId)
        {
            var candEntity = _candidateRepository.Find(cand =>
                    cand.Id == Guid.Parse(candId), _includes)
                .FirstOrDefault();

            _ = candEntity ?? throw new NotFoundException<ProjectCandidate>
                ($"Candidate with id: {candId} was not found.");

            candEntity = _mapper.Map<ProjectCandidate>(candidateRequest);
            candEntity.Id = Guid.Parse(candId);

            _candidateRepository.Update(candEntity);
            _uow.Save();

            return _mapper.Map<ProjectCandidateResponse>(_candidateRepository
                .Find(cand => cand.Id == candEntity.Id, _includes)
                .FirstOrDefault());
        }

        public void DeleteCandidate(string candId)
        {
            var candEntity = _candidateRepository
                .FindWithDeleted(mil => mil.Id.ToString() == candId)
                .FirstOrDefault();
            _ = candEntity ?? throw new NotFoundException<ProjectCandidate>
                ($"Candidate with id: {candId} was not found.");

            _candidateRepository.SoftDelete(Guid.Parse(candId));
            _uow.Save();
        }

    }
}
