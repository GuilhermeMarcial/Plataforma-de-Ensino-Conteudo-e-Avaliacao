using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IEnviarArquivosService
    {
        Task EnviarArquivos(string diretorioDaUnidade, IFormFile file);
    }
}