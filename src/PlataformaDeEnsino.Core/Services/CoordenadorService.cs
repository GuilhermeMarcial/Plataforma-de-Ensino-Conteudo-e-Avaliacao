using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;

namespace PlataformaDeEnsino.Core.Services
{
    public class CoordenadorService : ServiceBase<Coordenador, int>, ICoordenadorService
    {
        private readonly ICoordenadorRepository _coordenadorRepository;
        public CoordenadorService(ICoordenadorRepository coordenadorRepository) : base(coordenadorRepository)
        {
            _coordenadorRepository = coordenadorRepository;
        }
    }
}