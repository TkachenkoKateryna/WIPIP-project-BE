using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Persistence.Repositories;

namespace API.Installers
{
    public class RepositoriesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
