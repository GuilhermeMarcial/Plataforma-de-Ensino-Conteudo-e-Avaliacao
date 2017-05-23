using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces
{
    public interface IExtesaoValidaDoArquivoService
    {
        Task<bool> ExtensaoValidaDoArquivo(IFormFile file);
    }
}