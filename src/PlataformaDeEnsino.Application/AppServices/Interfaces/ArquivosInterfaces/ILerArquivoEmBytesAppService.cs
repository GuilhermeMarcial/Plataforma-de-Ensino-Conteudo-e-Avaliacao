using System.IO;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces
{
    public interface ILerArquivoEmBytesAppService
    {
        byte[] LerArquivoEmBytes(FileInfo file);
    }
}