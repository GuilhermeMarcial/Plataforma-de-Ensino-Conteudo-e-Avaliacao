using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories
{
    public interface IProfessorRepository : IRepositoryBase<Professor>
    {
        Task<IEnumerable<Professor>> ConsultarTodosProfessoresAsync();
        Task<Professor> ConsultarProfessorPeloId(int idDoProfessor);
        Task<Professor> ConsultarPeloCpfAsync(string cpfDaPessoa);
        Task<Professor> ConsultarPelaUnidadeAsync(int idDaUnidade);
    }
}