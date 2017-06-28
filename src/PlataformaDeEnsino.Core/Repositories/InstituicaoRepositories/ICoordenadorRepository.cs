using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories
{
    public interface ICoordenadorRepository : IRepositoryBase<Coordenador>
    {
          Task<Coordenador> ConsultarPeloCpfAsync(string cpfDaPessoa);
    }
}