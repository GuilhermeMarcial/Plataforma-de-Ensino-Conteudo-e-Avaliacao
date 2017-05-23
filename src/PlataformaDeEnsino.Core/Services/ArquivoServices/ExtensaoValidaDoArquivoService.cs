using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class ExtensaoValidaDoArquivoService : IExtesaoValidaDoArquivoService
    {
        public async Task<bool> ExtensaoValidaDoArquivo(IFormFile file)
        {
            var extensaoDoArquivo = await Task.Run(() => Path.GetExtension(file.FileName));
            
            return extensaoDoArquivo.Equals(".pdf") && file.ContentType.Equals("application/pdf");
        }
    }
}