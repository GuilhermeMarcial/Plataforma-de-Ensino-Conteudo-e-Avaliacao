using System;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface IModuloRepository : IRepositoryBase<Modulo>, IDisposable 
    {
         IEnumerable<Modulo> ConsultarModulosDaTurma(int idDaTurma);
    }
}