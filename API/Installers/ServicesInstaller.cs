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
            services.AddScoped<IJWTTokenService, JWTTokenService>();
        }
    }
}
