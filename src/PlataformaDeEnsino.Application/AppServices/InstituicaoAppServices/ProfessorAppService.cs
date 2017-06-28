using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.InstituicaoAppServices
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

        public async Task<Professor> ConsultarProfessorPeloId(int idDoProfessor)
        {
            return await _professorService.ConsultarProfessorPeloId(idDoProfessor);
        }

        public async Task<IEnumerable<Professor>> ConsultarTodosProfessoresAsync()
        {
            return await _professorService.ConsultarTodosProfessoresAsync();
        }
    }
}