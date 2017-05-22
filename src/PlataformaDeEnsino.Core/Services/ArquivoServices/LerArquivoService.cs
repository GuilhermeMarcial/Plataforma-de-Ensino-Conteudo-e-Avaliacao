using System.IO;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class LerArquivoService : ILerArquivoService
    {
        public FileInfo LerArquivo(string caminhoDoArquivo)
        {
            var file = new FileInfo(caminhoDoArquivo);
            return file;
        }
    }
}