using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces
{
    public interface IRecuperarArquivosService
    {
        Task<IEnumerable<FileInfo>> RecuperarArquivosAsync(string caminhoDoArquivo);
    }
}