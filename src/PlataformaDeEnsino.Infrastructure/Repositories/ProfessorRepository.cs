using System.Linq;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
        public async Task<Professor> ConsultarPeloCpfAsync(string cpfDoProfessor)
        {
            return await Context.Professores.Where(p => p.CpfDoProfessor == cpfDoProfessor).FirstAsync();
        }

        public async Task<Professor> ConsultarPelaUnidadeAsync(int idDoProfessor)
        {
            return await Context.Professores.Where(p => p.IdDoProfessor == idDoProfessor).FirstAsync();
        }
    }
}