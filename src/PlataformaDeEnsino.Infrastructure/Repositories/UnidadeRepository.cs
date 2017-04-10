using System.Collections.Generic;
using System.Linq;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class UnidadeRepository : RepositoryBase<Unidade, int>, IUnidadeRepository
    {
        public IEnumerable<Unidade> ConsultarUnidadadesDoModulo(int idDoModulo)
        {
           return Context.Unidades.Where(u => u.IdDoModulo == idDoModulo);
        }
    }
}