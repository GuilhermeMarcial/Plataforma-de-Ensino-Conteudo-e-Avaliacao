using System;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface IProfessorRepository : IRepositoryBase<Professor>, IDisposable
    {
         Professor ConsultarPeloCpf(string cpfDoProfessor);
         Professor ConsultarPelaUnidade(int idDaUnidade);
    }
}