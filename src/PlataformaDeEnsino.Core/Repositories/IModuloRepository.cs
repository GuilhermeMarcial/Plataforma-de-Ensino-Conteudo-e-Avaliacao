using System;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface IModuloRepository : IRepositoryBase<Modulo, int>, IDisposable 
    {
         IEnumerable<Modulo> ConsultarModulosDaTurma(int idDaTurma);
    }
}