using System.Linq;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;
using System;
using System.Collections.Generic;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
        public async Task<Professor> ConsultarPeloCpfAsync(string cpfDaPessoa)
        {
            return await context.Professores.AsNoTracking().Where(p => p.Pessoa.CpfDaPessoa == cpfDaPessoa).Include(p => p.Pessoa).FirstAsync();
        }

        public async Task<Professor> ConsultarPelaUnidadeAsync(int idDoProfessor)
        {
            return await context.Professores.AsNoTracking().Include(p => p.Pessoa).SingleOrDefaultAsync(pr => pr.IdDoProfessor == idDoProfessor);
        }

        public async Task<IEnumerable<Professor>> ConsultarTodosProfessoresAsync()
        {
            return await context.Professores.Include(p => p.Pessoa).ToListAsync();
        }

        public async Task<Professor> ConsultarProfessorPeloId(int idDoProfessor)
        {
            return await context.Professores.Include(p => p.Pessoa).Where(pr => pr.IdDoProfessor == idDoProfessor).FirstAsync();
        }
    }
}