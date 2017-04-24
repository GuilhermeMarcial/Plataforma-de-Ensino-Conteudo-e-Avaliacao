using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IAlunoAppService : IAppServiceBase<Aluno>
    {
        Aluno ConsultarAlunoPeloCpf(string CpfDoAluno);
        IEnumerable<Aluno> SelecionarAlunosPeloCurso(int idDoCurso);
    }
}