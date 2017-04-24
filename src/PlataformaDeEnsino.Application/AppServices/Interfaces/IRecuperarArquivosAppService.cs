using System.Collections.Generic;
using System.IO;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IRecuperarArquivosAppService
    {
        IEnumerable<FileInfo> RecuperarArquivos(string caminhoDoArquivo);
    }
}