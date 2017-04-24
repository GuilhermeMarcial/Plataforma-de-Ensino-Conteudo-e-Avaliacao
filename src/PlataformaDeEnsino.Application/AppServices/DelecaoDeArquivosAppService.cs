using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class DelecaoDeArquivosAppService : IDelecaoDeArquivosAppService
    {
        private readonly IDelecaoDeArquivosService _delegacaoDeArquivos;
        public DelecaoDeArquivosAppService(IDelecaoDeArquivosService delegacaoDeArquivos)
        {
            _delegacaoDeArquivos = delegacaoDeArquivos;
        }
        public void DeletarArquivo(string arquivo)
        {
             _delegacaoDeArquivos.DeletarArquivo(arquivo);
        }
    }
}