using System.IO;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class DelecaoDeArquivosService : IDelecaoDeArquivosService
    {
        public void DeletarArquivo(string arquivo)
        {
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }
        }
    }
}