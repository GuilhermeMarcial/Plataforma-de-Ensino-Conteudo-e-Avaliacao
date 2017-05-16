using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface ICoordenadorService : IServiceBase<Coordenador>, IDisposable
    {
         Coordenador ConsultarPeloCpf(string cpfDoCoordenador);
    }
}