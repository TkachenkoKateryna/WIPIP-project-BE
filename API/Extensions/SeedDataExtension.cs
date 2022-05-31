using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Persistence.EF;

namespace API.Extensions
{
    public static class SeedDataExtension
    {
        public static IHost SeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DataContext>();
            DataContextSeed.Seed(context);

            return host;
        }
    }
}
