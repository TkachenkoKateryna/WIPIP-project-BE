using System.Reflection;
using Domain.Interfaces.Util;

namespace API.Extensions
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration Configuration)
        {
            Assembly.GetAssembly(typeof(Startup))?
                .GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract && typeof(IInstaller).IsAssignableFrom(x))
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList()
                .ForEach(installer => installer.InstallServices(services, Configuration));
        }
    }
}
