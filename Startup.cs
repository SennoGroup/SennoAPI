using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.AspNetCore;
using SennoAPI.Attributes;
using SennoAPI.Authentication;
using SennoAPI.Extensions;
using SennoAPI.Services;

namespace SennoAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services
                .AddAuthentication(options => options.DefaultScheme = TokenAuthenticationHandler.SchemeName)
                .AddScheme<TokenAuthenticationOptions, TokenAuthenticationHandler>(TokenAuthenticationHandler.SchemeName,
                    options => { });

            services.AddTransient<ReportService>();
            services.AddTransient<FacialAnalysisService>();
            services.AddTransient<ThrottleAttribute>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Mapper.Initialize(configuration => configuration
                .CreateMappingsForLogs()
                .CreateMappingsForDomainModels());

            app.UseMvc();

            app.UseSwaggerUi3(typeof(Startup).Assembly, settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "alpha";
                    document.Info.Title = "Senno MVP API";
                    document.Info.Description = "Senno MVP API";
                    document.Info.Contact = new SwaggerContact
                    {
                        Name = "Senno",
                        Email = string.Empty,
                        Url = "https://mvp.senno.io"
                    };
                };
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
