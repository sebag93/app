using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Evento.Core.Repositories;
using Evento.Infrastructure.Repositories;
using Evento.Infrastructure.Services;
using Evento.Infrastructure.Mappers;
using Evento.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NLog.Extensions.Logging;
using NLog.Web;
using Newtonsoft.Json;

namespace Evento.Api    
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.Formating = Formatting.Indented);
            services.AddMemoryCache();
            services.AddAuthorization(x => x.AddPolicy("HasAdminRole", p => p.RequireRole("admin")));
            services.AddScoped<IEventRepository,EventRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IEventService,EventService>();
            services.AddScoped<ITicketService,TicketService>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddScoped<IUserService,UserService>();
            services.AddSingleton<IJwtHandler,JwtHandler>();
            services.Configure<JwtSettings>(Configuration.GetSection("jwt)"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            // loggerFactory.AddDebug();
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("nlog.config");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var jwtSettings = app.ApplicationServices.GetService<IOptions<JwtSettings>>();

            app.UseJwtBearerAuthentication(NewMethod(jwtSettings));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            static JwtBearerOptions NewMethod(IOptions<JwtSettings> jwtSettings)
            {
                return NewMethod1(jwtSettings);

                static JwtBearerOptions NewMethod1(IOptions<JwtSettings> jwtSettings)
                {
                    return new JwtBearerOptions
                    {
                        AutomaticAuthenticate = true,
                        TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = jwtSettings.Value.Issuer,
                            ValidateAudience = false,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Key))

                        }
                    };
                }
            }
        }
    }
}
