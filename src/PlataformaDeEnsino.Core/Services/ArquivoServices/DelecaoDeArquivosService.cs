using System.IO;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class DelecaoDeArquivosService : IDelecaoDeArquivosService
    {
        public async void DeletarArquivoAsync(string arquivo)
        {
            if (File.Exists(arquivo))
            {
                await Task.Run(() => File.Delete(arquivo));
            }
        }
    }
}