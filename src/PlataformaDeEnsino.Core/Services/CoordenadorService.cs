using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class CoordenadorService : ServiceBase<Coordenador>, ICoordenadorService
    {
        private readonly ICoordenadorRepository _coordenadorRepository;
        public CoordenadorService(ICoordenadorRepository coordenadorRepository) : base(coordenadorRepository)
        {
            _coordenadorRepository = coordenadorRepository;
        }

        public Coordenador ConsultarPeloCpf(string cpfDoCoordenador)
        {
            return _coordenadorRepository.ConsultarPeloCpf(cpfDoCoordenador);
        }
    }
}