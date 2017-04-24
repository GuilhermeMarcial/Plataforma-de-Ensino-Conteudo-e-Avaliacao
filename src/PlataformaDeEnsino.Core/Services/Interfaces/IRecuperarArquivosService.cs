using System.Collections.Generic;
using System.IO;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IRecuperarArquivosService
    {
        IEnumerable<FileInfo> RecuperarArquivos(string caminhoDoArquivo);
    }
}