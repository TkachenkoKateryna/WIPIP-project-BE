using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using Persistence.EF;

namespace API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "\\nlog.config"));
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        string connectionsString = Configuration["ConnectionStrings:DbWIPIP"];

        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionsString)
                .EnableSensitiveDataLogging());

        services.InstallServicesInAssembly(Configuration);
        services.AddControllers(opt =>
        {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        });

        services.AddCors();

        //services.AddSwaggerGen(c =>
        //{
        //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
        //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //    {
        //        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
        //              Enter 'Bearer' [space] and then your token in the text input below.
        //              \r\n\r\nExample: 'Bearer 12345abcdef'",
        //        Name = "Authorization",
        //        In = ParameterLocation.Header,
        //        Type = SecuritySchemeType.ApiKey,
        //        Scheme = "Bearer"
        //    });

        //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //    {
        //        {
        //            new OpenApiSecurityScheme
        //            {
        //                Reference = new OpenApiReference
        //                {
        //                    Type = ReferenceType.SecurityScheme,
        //                    Id = "Bearer"
        //                },
        //                Scheme = "oauth2",
        //                Name = "Bearer",
        //                In = ParameterLocation.Header
        //            },
        //            new List<string>()
        //        }
        //    });
        //});
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var d = env.IsDevelopment();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            //app.UseSwagger(c =>
            //{
            //    c.SerializeAsV2 = true;
            //});
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

            //    options.RoutePrefix = "swagger";
            //});
        }



        app.ConfigureCustomExceptionMiddleware();

        app.UseCors(x => x.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3001"));

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}