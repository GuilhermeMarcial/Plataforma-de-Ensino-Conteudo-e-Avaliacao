using System.IO;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class ArquivoNulloOuVazioService : IArquivoNulloOuVazioService
    {
        public bool ArquivoNulloOuVazio(IFormFile file)
        {
            return !file.Equals(null) && !file.Length.Equals(0);
        }
    }
}