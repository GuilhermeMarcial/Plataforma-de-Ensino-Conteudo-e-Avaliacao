using System;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>, IDisposable
    {
        Aluno ConsultarAlunoPeloCpf(string CpfDoAluno);
        IEnumerable<Aluno> SelecionarAlunosPeloCurso(int idDoCurso);
    }
}