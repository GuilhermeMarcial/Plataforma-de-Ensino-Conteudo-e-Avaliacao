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
        public async Task<Professor> ConsultarPeloCpfAsync(string cpfDaPessoa)
        {
            return await context.Professores.Where(p => p.CpfDaPessoa == cpfDaPessoa).FirstAsync();
        }

        public async Task<Professor> ConsultarPelaUnidadeAsync(int idDoProfessor)
        {
            return await context.Professores.Where(p => p.IdDoProfessor == idDoProfessor).FirstAsync();
        }
    }
}