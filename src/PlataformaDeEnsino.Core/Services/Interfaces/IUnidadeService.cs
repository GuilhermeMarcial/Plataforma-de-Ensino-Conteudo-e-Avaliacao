using System;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IUnidadeService : IServiceBase<Unidade>, IDisposable
    {
         IEnumerable<Unidade> ConsultarUnidadadesDoModulo(int idDoModulo);
    }
}