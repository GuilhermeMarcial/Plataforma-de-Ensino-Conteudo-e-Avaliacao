using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IUnidadeAppService : IAppServiceBase<Unidade>
    {
         Task<IEnumerable<Unidade>> ConsultarUnidadadesDoModuloAsync(int idDoModulo);
         Task<IEnumerable<Unidade>> ConsultarUnidadesDoProfessorAsync(int idDoProfessor);
    }
}