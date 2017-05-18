using System.Threading.Tasks;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IModuloAppService : IAppServiceBase<Modulo>
    {
         Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso);
         Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso, int nivelDoAluno);
    }
}