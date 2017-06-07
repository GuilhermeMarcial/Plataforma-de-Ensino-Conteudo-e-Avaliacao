using System.IO;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.ArquivosAppServices
{   
    public class LerArquivoAppService : ILerArquivoAppService
    {
        private readonly ILerArquivoService _lerArquivoService;

        public LerArquivoAppService(ILerArquivoService lerArquivoService)
        {
            _lerArquivoService = lerArquivoService;
        }

        public FileInfo LerArquivo(string caminhoDoArquivo)
        {
            return _lerArquivoService.LerArquivo(caminhoDoArquivo);
        }
    }
}