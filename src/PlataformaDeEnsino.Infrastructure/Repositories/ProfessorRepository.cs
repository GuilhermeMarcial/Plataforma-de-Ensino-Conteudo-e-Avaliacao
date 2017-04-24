using System.Linq;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
        public Professor ConsultarPeloCpf(string cpfDoProfessor)
        {
            return Context.Professores.Where(p => p.CpfDoProfessor == cpfDoProfessor).First();
        }

        public Professor ConsultarPelaUnidade(int idDoProfessor)
        {
            return Context.Professores.Where(p => p.IdDoProfessor == idDoProfessor).First();
        }
    }
}