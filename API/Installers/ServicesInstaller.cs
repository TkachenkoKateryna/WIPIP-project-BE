using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Domain.Interfaces.Util;
using Domain.Models.Dtos.Requests;
using Domain.Models.Validators;
using Domain.Services;
using Domain.Services.Util;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace API.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IStakeholdersService, StakeholdersService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IObjectiveService, ObjectiveService>();
            services.AddScoped<IAssumptionsService, AssumptionsService>();
            services.AddScoped<IDeliverablesService, DeliverablesService>();
            services.AddScoped<IMilestoneService, MilestoneService>();
            services.AddScoped<IRiskService, RiskService>();
            services.AddScoped<IRiskCategoriesService, RiskCategoriesService>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<IJWTTokenService, JWTTokenService>();
            services.AddScoped<IFileStorageService, AzureStorageService>();
            services.AddScoped<IExcelService, ExcelService>();
            services.AddScoped<IPDFService, PDFService>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddFluentValidation();
            services.AddTransient<IValidator<EmployeeRequest>, EmployeeValidator>();
        }
    }
}
