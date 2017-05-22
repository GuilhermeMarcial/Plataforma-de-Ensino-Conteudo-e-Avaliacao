using System.IO;

namespace PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces
{
    public interface ILerArquivoEmBytesService
    {
        byte[] LerArquivoEmBytes(FileInfo file);
    }
}