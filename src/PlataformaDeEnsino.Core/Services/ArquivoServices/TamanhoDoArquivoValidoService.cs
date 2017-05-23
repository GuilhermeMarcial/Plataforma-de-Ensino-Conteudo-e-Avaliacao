using System.IO;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class TamanhoDoArquivoValidoService : ITamanhoDoArquivoValidoService
    {
        public bool TamanhoDoArquivoValido(IFormFile file)
        {
            return file.Length <= 1073741824;
        }
    }
}