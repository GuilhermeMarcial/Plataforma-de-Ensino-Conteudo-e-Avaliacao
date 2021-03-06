using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class CoordenadorRepository : RepositoryBase<Coordenador>, ICoordenadorRepository
    {
       public async Task<Coordenador> ConsultarPeloCpfAsync(string cpfDaPessoa)
       {
           return await context.Coordenadores.AsNoTracking().Where(c => c.Pessoa.CpfDaPessoa == cpfDaPessoa).Include(p => p.Pessoa).FirstAsync();
       }
    }
}