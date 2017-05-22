using System.IO;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class LerArquivoEmBytesService : ILerArquivoEmBytesService
    {
        public byte[] LerArquivoEmBytes(FileInfo file)
        {
            var fileBytes = File.ReadAllBytes(file.FullName);
            return fileBytes;
        }
    }
}