using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PlataformaDeEnsino.Presenter.Mapper.ServiceCollectionExtensionsMapper
{
    public static class ServiceCollectionExtensionsMapper
    {
        public static void RegistrarDependenciasMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(Startup));
        }
    }
}