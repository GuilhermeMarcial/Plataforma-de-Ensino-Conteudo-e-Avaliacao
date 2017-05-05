using System.Collections.Generic;
using System.Linq;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class ModuloRepository : RepositoryBase<Modulo>, IModuloRepository
    {
        public IEnumerable<Modulo> ConsultarModulosDoCurso(int idDoCurso)
        {
            return Context.Modulos.Where(m => m.IdDoCurso == idDoCurso).ToList();
        }
        public IEnumerable<Modulo> ConsultarModulosDoCurso(int idDoCurso, int nivelDoAluno)
        {
            return Context.Modulos.Where(m => m.IdDoCurso == idDoCurso).Where(c => c.NivelDoModulo <= nivelDoAluno).ToList();
        }
    }
}