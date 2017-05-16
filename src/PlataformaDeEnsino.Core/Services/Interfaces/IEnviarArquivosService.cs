using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IEnviarArquivosService
    {
        Task EnviarArquivosAsync(string diretorioDaUnidade, IFormFile file);
    }
}