using Microsoft.Extensions.DependencyInjection;
using PlataformaDeEnsino.Application.AppServices.ArquivosAppServices;
using PlataformaDeEnsino.Application.AppServices.InstituicaoAppServices;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;

namespace PlataformaDeEnsino.Application.ServiceCollectionExtensionsApplicationService
{
    public static class ServiceCollectionExtensionsApplicationService
    {
        public static void RegistrarDependenciasApplicationService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            serviceCollection.AddScoped<IAlunoAppService, AlunoAppService>();
            serviceCollection.AddScoped<ICoordenadorAppService, CoordenadorAppService>();
            serviceCollection.AddScoped<ICursoAppService, CursoAppService>();
            serviceCollection.AddScoped<IModuloAppService, ModuloAppService>();
            serviceCollection.AddScoped<IProfessorAppService, ProfessorAppService>();
            serviceCollection.AddScoped<IUnidadeAppService, UnidadeAppService>();
            serviceCollection.AddScoped<ICriacaoDoDiretorioAppService, CriacaoDoDiretorioAppService>();
            serviceCollection.AddScoped<IDelecaoDeDiretoriosAppService, DelecaoDeDiretoriosAppService>();
            serviceCollection.AddScoped<IEnviarArquivosAppService, EnviarArquivosAppService>();
            serviceCollection.AddScoped<IRecuperarArquivosAppService, RecuperarArquivosAppService>();
            serviceCollection.AddScoped<IDelecaoDeArquivosAppService, DelecaoDeArquivosAppService>();
            serviceCollection.AddScoped<ILerArquivoAppService, LerArquivoAppService>();
            serviceCollection.AddScoped<ILerArquivoEmBytesAppService, LerArquivoEmBytesAppService>();
        }
    }
}