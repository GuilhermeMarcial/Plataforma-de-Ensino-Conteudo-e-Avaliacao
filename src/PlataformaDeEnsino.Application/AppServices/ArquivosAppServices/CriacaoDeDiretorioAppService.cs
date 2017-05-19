using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.ArquivosAppServices
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