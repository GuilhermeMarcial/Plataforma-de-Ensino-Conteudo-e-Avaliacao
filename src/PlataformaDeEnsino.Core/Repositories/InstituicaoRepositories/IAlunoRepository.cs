using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        Task<Aluno> ConsultarAlunoPeloId(int idDoAluno);
        Task<Aluno> ConsultarAlunoPeloCpfAsync(string cpfDaPessoa);
        Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso);
    }
}