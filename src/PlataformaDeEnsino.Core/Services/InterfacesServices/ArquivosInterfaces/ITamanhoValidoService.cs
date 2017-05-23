using System.IO;
using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces
{
    public interface ITamanhoDoArquivoValidoService
    {
        bool TamanhoDoArquivoValido(IFormFile file);
    }
}