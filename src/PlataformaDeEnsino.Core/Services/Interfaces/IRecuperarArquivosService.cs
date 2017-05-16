using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IRecuperarArquivosService
    {
        IEnumerable<FileInfo> RecuperarArquivos(string caminhoDoArquivo);
    }
}