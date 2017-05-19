using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories
{
    public interface ICoordenadorRepository : IRepositoryBase<Coordenador>, IDisposable
    {
          Task<Coordenador> ConsultarPeloCpfAsync(string cpfDoCoordenador);
    }
}