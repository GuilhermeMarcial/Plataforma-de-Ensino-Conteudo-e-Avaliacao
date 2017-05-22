using System.IO;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces
{
    public interface ILerArquivoAppService
    {
        FileInfo LerArquivoApp(string caminhoDoArquivo);
    }
}