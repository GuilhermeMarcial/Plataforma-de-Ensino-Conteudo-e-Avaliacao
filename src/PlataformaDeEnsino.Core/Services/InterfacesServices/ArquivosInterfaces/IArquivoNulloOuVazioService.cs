using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces
{
    public interface IArquivoNulloOuVazioService
    {
        bool ArquivoNulloOuVazio(IFormFile file);
    }
}