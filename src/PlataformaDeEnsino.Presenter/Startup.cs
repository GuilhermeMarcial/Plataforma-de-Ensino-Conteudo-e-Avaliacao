using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using AutoMapper;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Infrastructure.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Identity;
using PlataformaDeEnsino.Identity.Models;

namespace PlataformaDeEnsino.Presenter
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseMySql(
            Configuration["Data:ConteudoDBA:ConnectionString"]));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;

        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Lockout.MaxFailedAccessAttempts = 10;

        // Cookie settings
        options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
        options.Cookies.ApplicationCookie.LoginPath = "/Login";
        options.Cookies.ApplicationCookie.LogoutPath = "/LogOff";
        options.Cookies.ApplicationCookie.AccessDeniedPath = "/RedirecionarUsuario";

        // User settings
        options.User.RequireUniqueEmail = true;
    });

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICoordenadorRepository, CoordenadorRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IModuloRepository, ModuloRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICoordenadorService, CoordenadorService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IModuloService, ModuloService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IUnidadeService, UnidadeService>();
            services.AddScoped<ICriacaoDoDiretorioService, CriacaoDoDiretorioService>();
            services.AddScoped<IDelecaoDeDiretoriosService, DelecaoDeDiretoriosService>();
            services.AddScoped<IEnviarArquivosService, EnviarArquivosService>();
            services.AddScoped<IRecuperarArquivosService, RecuperarArquivosService>();
            services.AddScoped<IDelecaoDeArquivosService, DelecaoDeArquivosService>();
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<ICoordenadorAppService, CoordenadorAppService>();
            services.AddScoped<ICursoAppService, CursoAppService>();
            services.AddScoped<IModuloAppService, ModuloAppService>();
            services.AddScoped<IProfessorAppService, ProfessorAppService>();
            services.AddScoped<IUnidadeAppService, UnidadeAppService>();
            services.AddScoped<ICriacaoDoDiretorioAppService, CriacaoDoDiretorioAppService>();
            services.AddScoped<IDelecaoDeDiretoriosAppService, DelecaoDeDiretoriosAppService>();
            services.AddScoped<IEnviarArquivosAppService, EnviarArquivosAppService>();
            services.AddScoped<IRecuperarArquivosAppService, RecuperarArquivosAppService>();
            services.AddScoped<IDelecaoDeArquivosAppService, DelecaoDeArquivosAppService>();


        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseExceptionHandler("/Erro");
            app.UseStatusCodePagesWithRedirects("/Erro/{0}");
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc();
        }
    }
}
