using Application.Mapper;
using AutoMapper;
using Domain.Interfaces;

namespace API.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var autoMapperConfiguration = new MapperConfiguration(cfg =>
                    cfg.AddProfiles(new List<Profile> { new MappingProfile() }))
                .CreateMapper();
            services.AddSingleton(autoMapperConfiguration);
        }
    }
}
