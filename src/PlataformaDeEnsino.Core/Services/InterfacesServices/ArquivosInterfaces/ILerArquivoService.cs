using System.IO;

namespace PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces
{
    public interface ILerArquivoService
    {
         FileInfo LerArquivo(string caminhoDoArquivo);
    }
}