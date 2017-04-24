using System;
using System.Collections.Generic;
using System.Linq;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public Aluno ConsultarAlunoPeloCpf(string cpfDoAluno)
        {
            return Context.Alunos.Where(a => a.CpfDoAluno == cpfDoAluno).First();
        }

        public IEnumerable<Aluno> SelecionarAlunosPeloCurso(int idDoCurso)
        {
            return Context.Alunos.Where(a => a.IdDoCurso == idDoCurso).ToList();
        }
    }
}