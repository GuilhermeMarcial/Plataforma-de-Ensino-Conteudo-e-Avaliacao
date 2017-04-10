using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;

namespace PlataformaDeEnsino.Core.Services
{
    public class CursoService : ServiceBase<Curso, int>, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository) : base(cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
    }
}