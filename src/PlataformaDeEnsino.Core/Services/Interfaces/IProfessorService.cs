using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IProfessorService : IServiceBase<Professor>, IDisposable
    {
         Task<Professor> ConsultarPeloCpfAsync(string cpfDoProfessor);
         Task<Professor> ConsultarPelaUnidadeAsync(int idDaUnidade);
    }
}