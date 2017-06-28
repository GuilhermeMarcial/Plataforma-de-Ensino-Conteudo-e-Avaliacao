using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces
{
    public interface IProfessorService : IServiceBase<Professor>
    {
        Task<IEnumerable<Professor>> ConsultarTodosProfessoresAsync();
        Task<Professor> ConsultarProfessorPeloId(int idDoProfessor);
        Task<Professor> ConsultarPeloCpfAsync(string cpfDoProfessor);
        Task<Professor> ConsultarPelaUnidadeAsync(int idDaUnidade);
    }
}