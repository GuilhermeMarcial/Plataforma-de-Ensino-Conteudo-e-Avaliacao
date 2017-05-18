using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public async Task<Aluno> ConsultarAlunoPeloCpfAsync(string cpfDoAluno)
        {
            return await Context.Alunos.SingleAsync(a => a.CpfDoAluno == cpfDoAluno);
        }

        public async Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso)
        {
            return await Context.Alunos.Where(a => a.IdDoCurso == idDoCurso).ToListAsync();
        }
    }
}