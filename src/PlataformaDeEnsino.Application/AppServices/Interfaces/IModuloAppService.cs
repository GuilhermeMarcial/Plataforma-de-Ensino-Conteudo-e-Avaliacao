using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IModuloAppService : IAppServiceBase<Modulo>
    {
         IEnumerable<Modulo> ConsultarModulosDaTurma(int idDaTurma);
    }
}