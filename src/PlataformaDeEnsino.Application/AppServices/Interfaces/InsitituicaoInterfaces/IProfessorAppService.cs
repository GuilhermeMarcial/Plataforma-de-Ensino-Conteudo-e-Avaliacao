using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces
{
    public interface IProfessorAppService : IAppServiceBase<Professor>
    {
        Task<IEnumerable<Professor>> ConsultarTodosProfessoresAsync();
        Task<Professor> ConsultarProfessorPeloId(int idDoProfessor);
        Task<Professor> ConsultarPeloCpfAsync(string cpfDoProfessor);
        Task<Professor> ConsultarPelaUnidadeAsync(int idDaUnidade);
    }
}