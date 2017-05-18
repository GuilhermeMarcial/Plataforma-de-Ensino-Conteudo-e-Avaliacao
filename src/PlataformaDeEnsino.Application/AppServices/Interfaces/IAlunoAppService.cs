using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IAlunoAppService : IAppServiceBase<Aluno>
    {
        Task<Aluno> ConsultarAlunoPeloCpfAsync(string CpfDoAluno);
        Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso);
    }
}