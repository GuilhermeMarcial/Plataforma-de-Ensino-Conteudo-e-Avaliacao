using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IRecuperarArquivosAppService
    {
        IEnumerable<FileInfo> RecuperarArquivos(string caminhoDoArquivo);
    }
}