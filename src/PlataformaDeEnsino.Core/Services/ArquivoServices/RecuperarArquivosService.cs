using System.IO;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Services.Interfaces;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class RecuperarArquivosService : IRecuperarArquivosService
    {
        public async Task<IEnumerable<FileInfo>> RecuperarArquivosAsync(string caminhoDoArquivo)
        {
            var diretorio = new DirectoryInfo(caminhoDoArquivo);
            return diretorio.Exists ? await Task.Run(() => diretorio.EnumerateFiles()) : null;
        }
    }
}