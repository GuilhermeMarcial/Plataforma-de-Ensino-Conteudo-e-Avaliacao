using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IRecuperarArquivosAppService
    {
        Task<IEnumerable<FileInfo>> RecuperarArquivosAsync(string caminhoDoArquivo);
    }
}