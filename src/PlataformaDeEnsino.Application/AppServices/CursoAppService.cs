using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
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