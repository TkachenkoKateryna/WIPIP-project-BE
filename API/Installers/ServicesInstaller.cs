using Application.Interfaces;
using Application.Interfaces.Util;
using Application.Services;
using Application.Services.Util;
using Domain.Interfaces;

namespace API.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IStakeholdersService, StakeholdersService>();
            services.AddScoped<IObjectiveService, ObjectiveService>();
            services.AddScoped<IAssumptionsService, AssumptionsService>();
            services.AddScoped<IDeliverablesService, DeliverablesService>();
            services.AddScoped<IMilestoneService, MilestoneService>();
            services.AddScoped<IRiskService, RiskService>();
            services.AddScoped<IJWTTokenService, JWTTokenService>();
            services.AddScoped<IFileStorageService, AzureStorageService>();
            services.AddScoped<IPDFService, PDFService>();
        }
    }
}
