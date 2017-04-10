using System.Collections.Generic;
using System.Linq;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class ModuloRepository : RepositoryBase<Modulo, int>, IModuloRepository
    {
        public IEnumerable<Modulo> ConsultarModulosDaTurma(int idDaTurma)
        {
            return Context.Modulos.Where(m => m.IdDaTurma == idDaTurma).Where(e => e.EstadoDoModulo.Equals(true));
        }
    }
}