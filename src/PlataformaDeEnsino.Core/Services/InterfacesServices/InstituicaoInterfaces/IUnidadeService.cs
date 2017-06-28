using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces
{
    public interface IUnidadeService : IServiceBase<Unidade>
    {
         Task<IEnumerable<Unidade>> ConsultarUnidadadesDoModuloAsync(int idDoModulo);
         Task<IEnumerable<Unidade>> ConsultarUnidadesDoProfessorAsync(int idDoProfessor);
    }
}