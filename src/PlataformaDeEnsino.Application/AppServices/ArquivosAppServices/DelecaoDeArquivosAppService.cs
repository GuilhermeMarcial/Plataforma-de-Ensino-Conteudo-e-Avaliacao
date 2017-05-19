using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.ArquivosAppServices
{
    public class DelecaoDeArquivosAppService : IDelecaoDeArquivosAppService
    {
        private readonly IDelecaoDeArquivosService _delegacaoDeArquivos;
        public DelecaoDeArquivosAppService(IDelecaoDeArquivosService delegacaoDeArquivos)
        {
            _delegacaoDeArquivos = delegacaoDeArquivos;
        }
        public async void DeletarArquivoAsync(string arquivo)
        {
             await Task.Run(() => _delegacaoDeArquivos.DeletarArquivoAsync(arquivo));
        }
    }
}