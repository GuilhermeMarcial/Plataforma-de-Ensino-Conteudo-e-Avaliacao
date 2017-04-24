using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
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
             await _enviarArquivosService.EnviarArquivos(diretorioDaUnidade, file);
        }
    }
}