using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class ProfessorAppService : AppServiceBase<Professor>, IProfessorAppService
    {
        private readonly IProfessorService _professorService;
        public ProfessorAppService(IProfessorService professorService) : base(professorService)
        {
            _professorService = professorService;
        }

        public async Task<Professor> ConsultarPelaUnidadeAsync(int idDaUnidade)
        {
            return await _professorService.ConsultarPelaUnidadeAsync(idDaUnidade);
        }
        public async Task<Professor> ConsultarPeloCpfAsync(string cpfDoProfessor)
        {
            return await _professorService.ConsultarPeloCpfAsync(cpfDoProfessor);
        }
    }
}