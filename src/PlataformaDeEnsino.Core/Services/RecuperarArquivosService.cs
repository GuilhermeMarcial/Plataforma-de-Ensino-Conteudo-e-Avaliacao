using System.IO;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class RecuperarArquivosService : IRecuperarArquivosService
    {
        public IEnumerable<FileInfo> RecuperarArquivos(string caminhoDoArquivo)
        {
            var diretorio = new DirectoryInfo(caminhoDoArquivo);
            return (diretorio.Exists) ? diretorio.EnumerateFiles() : null;
        }
    }
}