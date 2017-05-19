using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.ArquivosAppServices
{
    public class EnviarArquivosAppService : IEnviarArquivosAppService
    {
        private readonly IEnviarArquivosService _enviarArquivosService;
        public EnviarArquivosAppService(IEnviarArquivosService enviarArquivosService)
        {
            _enviarArquivosService = enviarArquivosService;
        }
        public async Task EnviarArquivos(string diretorioDaUnidade, IFormFile file)
        {
             await _enviarArquivosService.EnviarArquivosAsync(diretorioDaUnidade, file);
        }
    }
}