using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IRecuperarArquivosService
    {
        Task<IEnumerable<FileInfo>> RecuperarArquivosAsync(string caminhoDoArquivo);
    }
}