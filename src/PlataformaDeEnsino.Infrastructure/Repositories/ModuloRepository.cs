using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class ModuloRepository : RepositoryBase<Modulo>, IModuloRepository
    {
        public async Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso)
        {
            return await Context.Modulos.Where(m => m.IdDoCurso == idDoCurso).ToListAsync();
        }
        public async Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso, int nivelDoAluno)
        {
            return await Context.Modulos.Where(m => m.IdDoCurso == idDoCurso).Where(c => c.NivelDoModulo <= nivelDoAluno).ToListAsync();
        }
    }
}