using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IUnidadeAppService : IAppServiceBase<Unidade>
    {
         IEnumerable<Unidade> ConsultarUnidadadesDoModulo(int idDoModulo);
         IEnumerable<Unidade> ConsultarUnidadesDoProfessor(int idDoProfessor);
    }
}