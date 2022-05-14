using Application.Interfaces;
using Application.Interfaces.Util;
using AutoMapper;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly Func<IQueryable<Project>, IIncludableQueryable<Project, object>> _includes;
        private readonly IRepository<Project> _projectRepository;
        private readonly IStakeholdersService _stakeholderService;
        private readonly IPDFService _pdfService;

        public ProjectService(IUnitOfWork uow, IMapper mapper, IStakeholdersService stakeholderService, IPDFService pdfService)
        {
            _uow = uow;
            _projectRepository = _uow.GetRepository<Project>();
            _stakeholderService = stakeholderService;
            _mapper = mapper;
            _pdfService = pdfService;
            _includes = project => project.Include(p => p.Objectives)
                .Include(p => p.Assumptions)
                .Include(p => p.ProjectStakeholders).ThenInclude(st => st.Stakeholder);
        }

        public ProjectResponse GetProjectById(string projId)
        {
            var project = _projectRepository.Find(p => p.Id == Guid.Parse(projId), _includes)
                .Select(empEntity => _mapper.Map<ProjectResponse>(empEntity))
                .FirstOrDefault();
            project.Stakeholders = _stakeholderService.GetAllStakeholdersByProject(projId).ToList();

            return project;
        }

        public IEnumerable<ProjectResponse> GetProjectsByManager(string managerId)
        {

            var projects = _projectRepository.FindWithDeleted(p => p.ManagerId == managerId, _includes)
                .Select(empEntity => _mapper.Map<ProjectResponse>(empEntity))
                .ToList();

            return projects;
        }

    }
}
