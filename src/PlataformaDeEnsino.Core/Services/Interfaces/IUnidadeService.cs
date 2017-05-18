using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IUnidadeService : IServiceBase<Unidade>, IDisposable
    {
         Task<IEnumerable<Unidade>> ConsultarUnidadadesDoModuloAsync(int idDoModulo);
         Task<IEnumerable<Unidade>> ConsultarUnidadesDoProfessorAsync(int idDoProfessor);
    }
}