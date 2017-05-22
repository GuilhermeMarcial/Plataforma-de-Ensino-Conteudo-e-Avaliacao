using Microsoft.Extensions.DependencyInjection;
using PlataformaDeEnsino.Core.Services.ArquivoServices;
using PlataformaDeEnsino.Core.Services.InstituicaoServices;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ServiceCollectionExtensionsServices
{
    public static class ServiceCollectionExtensionsServices
    {
        public static void RegistrarDependenciasServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            serviceCollection.AddScoped<IAlunoService, AlunoService>();
            serviceCollection.AddScoped<ICoordenadorService, CoordenadorService>();
            serviceCollection.AddScoped<ICursoService, CursoService>();
            serviceCollection.AddScoped<IModuloService, ModuloService>();
            serviceCollection.AddScoped<IProfessorService, ProfessorService>();
            serviceCollection.AddScoped<IUnidadeService, UnidadeService>();
            serviceCollection.AddScoped<ICriacaoDoDiretorioService, CriacaoDoDiretorioService>();
            serviceCollection.AddScoped<IDelecaoDeDiretoriosService, DelecaoDeDiretoriosService>();
            serviceCollection.AddScoped<IEnviarArquivosService, EnviarArquivosService>();
            serviceCollection.AddScoped<IRecuperarArquivosService, RecuperarArquivosService>();
            serviceCollection.AddScoped<IDelecaoDeArquivosService, DelecaoDeArquivosService>();
            serviceCollection.AddScoped<ILerArquivoService, LerArquivoService>();
            serviceCollection.AddScoped<ILerArquivoEmBytesService, LerArquivoEmBytesService>();
        }
    }
}