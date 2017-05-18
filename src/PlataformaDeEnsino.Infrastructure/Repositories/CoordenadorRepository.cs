using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class CoordenadorRepository : RepositoryBase<Coordenador>, ICoordenadorRepository
    {
       public async Task<Coordenador> ConsultarPeloCpfAsync(string cpfDoCoordenador)
       {
           return await Context.Coordenadores.Where(c => c.CpfDoCoordenador == cpfDoCoordenador).FirstAsync();
       }
    }
}