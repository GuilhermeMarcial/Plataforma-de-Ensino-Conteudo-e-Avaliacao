using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class ProfessorAppService : AppServiceBase<Professor, int>, IProfessorAppService
    {
        private readonly IProfessorService _professorService;
        public ProfessorAppService(IProfessorService professorService) : base(professorService)
        {
            _professorService = professorService;
        }
    }
}