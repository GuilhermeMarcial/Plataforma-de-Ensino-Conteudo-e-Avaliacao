using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using AutoMapper;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Infrastructure.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services;

namespace PlataformaDeEnsino.Presenter
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>)); 
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICoordenadorRepository, CoordenadorRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IModuloRepository, ModuloRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICoordenadorService, CoordenadorService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IModuloService, ModuloService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IUnidadeService, UnidadeService>();
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<ICoordenadorAppService, CoordenadorAppService>();
            services.AddScoped<ICursoAppService, CursoAppService>();
            services.AddScoped<IModuloAppService, ModuloAppService>();
            services.AddScoped<IProfessorAppService, ProfessorAppService>();
            services.AddScoped<ITurmaAppService, TurmaAppService>();
            services.AddScoped<IUnidadeAppService, UnidadeAppService>();

            
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseMvc();
        }
    }
}
