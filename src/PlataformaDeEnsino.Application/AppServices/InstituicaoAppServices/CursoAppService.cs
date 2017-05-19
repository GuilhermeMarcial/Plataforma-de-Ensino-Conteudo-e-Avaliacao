using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.InstituicaoAppServices
{
    public class CursoAppService : AppServiceBase<Curso>, ICursoAppService
    {
        private readonly ICursoService _cursoService;
        public CursoAppService(ICursoService cursoService) : base(cursoService)
        {
            _cursoService = cursoService;
        }

    }
}