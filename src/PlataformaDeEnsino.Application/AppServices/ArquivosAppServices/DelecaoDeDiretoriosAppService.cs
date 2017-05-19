using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.ArquivosAppServices
{
    public class DelecaoDeDiretoriosAppService : IDelecaoDeDiretoriosAppService
    {
        private readonly IDelecaoDeDiretoriosService _delecaoDeDiretorios;
        public DelecaoDeDiretoriosAppService(IDelecaoDeDiretoriosService delecaoDeDiretorios)
        {
            _delecaoDeDiretorios = delecaoDeDiretorios;
        }
        public void DeletarDiretorio(string diretorio)
        {
            _delecaoDeDiretorios.DeletarDiretorio(diretorio);
        }
    }
}