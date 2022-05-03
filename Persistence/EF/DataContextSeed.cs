using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF
{
    public class DataContextSeed
    {
        public static void Seed(DataContext context, int retry = 0)
        {
            try
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                if (retry >= 10)
                {
                    throw;
                }

                retry++;
                Seed(context, retry);
                throw;
            }
        }
    }
}
