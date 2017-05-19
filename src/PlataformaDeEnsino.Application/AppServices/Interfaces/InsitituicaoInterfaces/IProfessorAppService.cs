using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces
{
    public interface IProfessorAppService : IAppServiceBase<Professor>
    {
         Task<Professor> ConsultarPeloCpfAsync(string cpfDoProfessor);
         Task<Professor> ConsultarPelaUnidadeAsync(int idDaUnidade);
    }
}