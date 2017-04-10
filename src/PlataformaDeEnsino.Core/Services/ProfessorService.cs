using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class ProfessorService : ServiceBase<Professor, int>, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorService(IProfessorRepository professorRepository) : base(professorRepository)
        {
            _professorRepository = professorRepository;
        }
    }
}