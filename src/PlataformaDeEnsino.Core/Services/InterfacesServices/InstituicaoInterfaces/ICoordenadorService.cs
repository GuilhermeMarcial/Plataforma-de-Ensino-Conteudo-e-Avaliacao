using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces
{
    public interface ICoordenadorService : IServiceBase<Coordenador>
    {
         Task<Coordenador> ConsultarPeloCpfAsync(string cpfDoCoordenador);
    }
}