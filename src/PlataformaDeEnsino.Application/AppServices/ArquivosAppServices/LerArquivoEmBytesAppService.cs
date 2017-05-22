using System.IO;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.ArquivosAppServices
{
    public class LerArquivoEmBytesAppService : ILerArquivoEmBytesAppService
    {
        private readonly ILerArquivoEmBytesService _lerArquivoEmBytesService;

        public LerArquivoEmBytesAppService(ILerArquivoEmBytesService lerArquivoEmBytesService)
        {
            _lerArquivoEmBytesService = lerArquivoEmBytesService;
        }

        public byte[] LerArquivoEmBytes(FileInfo file)
        {
            return _lerArquivoEmBytesService.LerArquivoEmBytes(file);
        }
    }
}