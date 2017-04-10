using System;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface IUnidadeRepository : IRepositoryBase<Unidade, int>, IDisposable
    {
         IEnumerable<Unidade> ConsultarUnidadadesDoModulo(int idDoModulo);
    }
}