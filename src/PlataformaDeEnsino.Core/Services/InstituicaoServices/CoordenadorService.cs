using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Core.Services.InstituicaoServices
{
    public class CoordenadorService : ServiceBase<Coordenador>, ICoordenadorService
    {
        private readonly ICoordenadorRepository _coordenadorRepository;
        public CoordenadorService(ICoordenadorRepository coordenadorRepository) : base(coordenadorRepository)
        {
            _coordenadorRepository = coordenadorRepository;
        }

        public async Task<Coordenador> ConsultarPeloCpfAsync(string cpfDoCoordenador)
        {
            return await _coordenadorRepository.ConsultarPeloCpfAsync(cpfDoCoordenador);
        }
    }
}