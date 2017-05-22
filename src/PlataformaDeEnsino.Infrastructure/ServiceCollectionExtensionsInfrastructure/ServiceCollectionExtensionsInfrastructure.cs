using Microsoft.Extensions.DependencyInjection;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;
using PlataformaDeEnsino.Infrastructure.Repositories;

namespace PlataformaDeEnsino.Infrastructure.ServiceCollectionExtensionsInfrastructure
{
    public static class ServiceCollectionExtensionsInfrastructure
    {
        
            public static void RegistrarDependenciasInfrastructure(this IServiceCollection serviceCollection)
            {
                serviceCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
                serviceCollection.AddScoped<IAlunoRepository, AlunoRepository>();
                serviceCollection.AddScoped<ICoordenadorRepository, CoordenadorRepository>();
                serviceCollection.AddScoped<ICursoRepository, CursoRepository>();
                serviceCollection.AddScoped<IModuloRepository, ModuloRepository>();
                serviceCollection.AddScoped<IProfessorRepository, ProfessorRepository>();
                serviceCollection.AddScoped<IUnidadeRepository, UnidadeRepository>();
            }
        
    }
}