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
            return await context.Alunos.SingleAsync(a => a.CpfDaPessoa == cpfDaPessoa);
        }

        public async Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso)
        {
            return await context.Alunos.Where(a => a.IdDoCurso == idDoCurso).ToListAsync();
        }
    }
}