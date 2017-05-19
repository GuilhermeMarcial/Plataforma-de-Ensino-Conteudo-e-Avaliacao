using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces
{
    public interface IAlunoService : IServiceBase<Aluno>, IDisposable
    {
       Task<Aluno> ConsultarAlunoPeloCpfAsync(string CpfDoAluno);
       Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso); 
    }
}