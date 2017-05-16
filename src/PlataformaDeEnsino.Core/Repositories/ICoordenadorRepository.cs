using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface ICoordenadorRepository : IRepositoryBase<Coordenador>, IDisposable
    {
         Coordenador ConsultarPeloCpf(string cpfDoCoordenador);
    }
}