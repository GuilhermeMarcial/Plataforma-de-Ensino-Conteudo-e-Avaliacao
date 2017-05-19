using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces
{
    public interface IEnviarArquivosAppService
    {
        Task EnviarArquivos(string diretorioDaUnidade, IFormFile file);
    }
}