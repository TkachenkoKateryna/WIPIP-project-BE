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
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IStakeholdersService, StakeholdersService>();
            services.AddScoped<IObjectiveService, ObjectiveService>();
            services.AddScoped<IAssumptionsService, AssumptionsService>();
            services.AddScoped<IDeliverablesService, DeliverablesService>();
            services.AddScoped<IJWTTokenService, JWTTokenService>();
        }
    }
}
