using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IUnidadeService : IServiceBase<Unidade>, IDisposable
    {
         IEnumerable<Unidade> ConsultarUnidadadesDoModulo(int idDoModulo);
         IEnumerable<Unidade> ConsultarUnidadesDoProfessor(int idDoProfessor);
    }
}