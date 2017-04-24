using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class CriacaoDoDiretorioAppService : ICriacaoDoDiretorioAppService
    {
        private readonly ICriacaoDoDiretorioService _criacaoDoDiretorio;
        public CriacaoDoDiretorioAppService(ICriacaoDoDiretorioService criacaoDoDiretorio)
        {
            _criacaoDoDiretorio = criacaoDoDiretorio;
        }

        public void CriarDiretorio(string caminhoDoDiretorio)
        {
            _criacaoDoDiretorio.CriarDiretorio(caminhoDoDiretorio);
        }
    }
}