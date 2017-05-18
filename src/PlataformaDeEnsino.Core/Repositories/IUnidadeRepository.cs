using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface IUnidadeRepository : IRepositoryBase<Unidade>, IDisposable
    {
         Task<IEnumerable<Unidade>> ConsultarUnidadadesDoModuloAsync(int idDoModulo);

         Task<IEnumerable<Unidade>> ConsultarUnidadesDoProfessorAsync(int idDoProfessor);
    }
}