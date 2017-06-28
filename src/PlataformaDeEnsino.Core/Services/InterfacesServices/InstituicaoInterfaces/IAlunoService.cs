using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces
{
    public interface IAlunoService : IServiceBase<Aluno>
    {
       Task<Aluno> ConsultarAlunoPeloId(int idDoAluno);
       Task<Aluno> ConsultarAlunoPeloCpfAsync(string cpfDoAluno);
       Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso);
    }
}