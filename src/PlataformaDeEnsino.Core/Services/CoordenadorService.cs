using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

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