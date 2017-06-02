using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Core.Identity;
using PlataformaDeEnsino.Identity.ServiceCollectionExtensionsIdentity;
using PlataformaDeEnsino.Core.Services.ServiceCollectionExtensionsServices;
using PlataformaDeEnsino.Presenter.Mapper.ServiceCollectionExtensionsMapper;
using PlataformaDeEnsino.Infrastructure.ServiceCollectionExtensionsInfrastructure;
using PlataformaDeEnsino.Application.ServiceCollectionExtensionsApplicationService;

namespace PlataformaDeEnsino.Presenter
{
    public class Startup
    {
        IConfigurationRoot configuration;
        public Startup(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()))
            .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseMySql(
            configuration["Data:ConteudoDBA:ConnectionString"]));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            services.RegistrarDependenciasIdentity();
            services.RegistrarDependenciasMapper();
            services.RegistrarDependenciasInfrastructure();
            services.RegistrarDependenciasServices();
            services.RegistrarDependenciasApplicationService();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseExceptionHandler("/Erro");
            app.UseStatusCodePagesWithRedirects("/Erro/{0}");
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc();
            app.Use(async (contex, next) => { contex.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN"); await next(); });
        }
    }
}
