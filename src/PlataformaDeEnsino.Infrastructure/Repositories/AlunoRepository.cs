using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public async Task<Aluno> ConsultarAlunoPeloCpfAsync(string cpfDaPessoa)
        {
            return await context.Alunos.AsNoTracking().Where(a => a.Pessoa.CpfDaPessoa == cpfDaPessoa).Include(p => p.Pessoa).FirstAsync();
        }

        public async Task<Aluno> ConsultarAlunoPeloId(int idDoAluno)
        {
            return await context.Alunos.AsNoTracking().Where(a => a.IdDoAluno == idDoAluno).Include(p => p.Pessoa).FirstAsync();
        }

        public async Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso)
        {
            return await context.Alunos.AsNoTracking().Where(a => a.IdDoCurso == idDoCurso).Include(p => p.Pessoa).ToListAsync();
        }
    }
}