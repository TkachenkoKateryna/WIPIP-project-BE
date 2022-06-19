using System.Text;
using Domain.Interfaces.Util;
using Domain.Models.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence.EF;

namespace API.Installers
{
    public class IdentityServiceInstaller
    {
        public class IdentityServiceExtensions : IInstaller
        {
            public void InstallServices(IServiceCollection services, IConfiguration config)
            {
                services.AddIdentityCore<User>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                })
                    .AddRoles<Role>()
                    .AddEntityFrameworkStores<DataContext>()
                    .AddSignInManager<SignInManager<User>>()
                    .AddRoleManager<RoleManager<Role>>();


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
