using Domain.Interfaces;
using Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace API.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string connectionsString = configuration.GetConnectionString("DbWIPIP");

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionsString)
                    .EnableSensitiveDataLogging());
        }
    }
}
