using System.Linq;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class CoordenadorRepository : RepositoryBase<Coordenador>, ICoordenadorRepository
    {
       public Coordenador ConsultarPeloCpf(string cpfDoCoordenador)
       {
           return Context.Coordenadores.Where(c => c.CpfDoCoordenador == cpfDoCoordenador).First();
       }
    }
}