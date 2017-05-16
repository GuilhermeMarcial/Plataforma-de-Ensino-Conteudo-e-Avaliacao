using System.IO;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class RecuperarArquivosAppService : IRecuperarArquivosAppService
    {
        private readonly IRecuperarArquivosService _recuperarArquivos;
        public RecuperarArquivosAppService(IRecuperarArquivosService recuperarArquivos)
        {
            _recuperarArquivos = recuperarArquivos;
        }
        public IEnumerable<FileInfo> RecuperarArquivos(string caminhoDoArquivo)
        {
            return _recuperarArquivos.RecuperarArquivos(caminhoDoArquivo);
        }
    }
}