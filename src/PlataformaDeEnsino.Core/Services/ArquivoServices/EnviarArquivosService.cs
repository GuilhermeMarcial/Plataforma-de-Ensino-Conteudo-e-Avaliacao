using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class EnviarArquivosService : IEnviarArquivosService
    {
        private readonly IArquivoValidoService _arquivoValidoService;

        public EnviarArquivosService(IArquivoValidoService arquivoValidoService)
        {
            _arquivoValidoService = arquivoValidoService;
        }

        public async Task EnviarArquivosAsync(string diretorioDaUnidade, IFormFile file)
        {
            if (await _arquivoValidoService.ArquivoValido(diretorioDaUnidade, file))
            {
                var filePath = Path.Combine(diretorioDaUnidade, file.FileName.Trim('"'));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }
    }
}