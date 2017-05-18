using System.IO;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Core.Services
{
    public class RecuperarArquivosService : IRecuperarArquivosService
    {
        public async Task<IEnumerable<FileInfo>> RecuperarArquivosAsync(string caminhoDoArquivo)
        {
            var diretorio = new DirectoryInfo(caminhoDoArquivo);
            return (diretorio.Exists) ? await Task.Run(() => diretorio.EnumerateFiles()) : null;
        }
    }
}