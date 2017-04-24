using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
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