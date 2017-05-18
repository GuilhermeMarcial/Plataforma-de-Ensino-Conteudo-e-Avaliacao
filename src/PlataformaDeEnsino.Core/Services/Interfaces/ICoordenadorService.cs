using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface ICoordenadorService : IServiceBase<Coordenador>, IDisposable
    {
         Task<Coordenador> ConsultarPeloCpfAsync(string cpfDoCoordenador);
    }
}