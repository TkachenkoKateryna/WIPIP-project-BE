using Domain.Models.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence.EF;
using System.Text;
using Domain.Models.Entities.Identity;

namespace API.Installers
{
    public class IdentityServiceInstaller
    {
        public class IdentityServiceExtensions : IInstaller
        {
            public void InstallServices(IServiceCollection services,
                IConfiguration config)
            {
                services.AddIdentityCore<User>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<DataContext>()
                    .AddSignInManager<SignInManager<User>>();

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));

                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = key,
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero
                        };
                    });
            }

        }
    }
}
