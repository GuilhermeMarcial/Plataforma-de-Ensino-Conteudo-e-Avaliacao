using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces
{
    public interface IArquivoValidoService
    {
        Task<bool> ArquivoValido(string caminhoDoArquivo, IFormFile file);
    }
}