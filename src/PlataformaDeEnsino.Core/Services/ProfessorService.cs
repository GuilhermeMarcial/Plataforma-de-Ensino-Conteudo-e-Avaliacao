using System;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class ProfessorService : ServiceBase<Professor>, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorService(IProfessorRepository professorRepository) : base(professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public Professor ConsultarPelaUnidade(int idDaUnidade)
        {
            return _professorRepository.ConsultarPelaUnidade(idDaUnidade);
        }

        public Professor ConsultarPeloCpf(string cpfDoProfessor)
        {
            return _professorRepository.ConsultarPeloCpf(cpfDoProfessor);
        }
    }
}