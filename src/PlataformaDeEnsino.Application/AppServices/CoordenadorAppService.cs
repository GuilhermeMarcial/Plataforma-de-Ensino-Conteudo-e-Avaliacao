using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class CoordenadorAppService : AppServiceBase<Coordenador>, ICoordenadorAppService
    {
        private readonly ICoordenadorService _coordenadorService;
        public CoordenadorAppService(ICoordenadorService coordenadorService) : base(coordenadorService)
        {
            _coordenadorService = coordenadorService;
        }

        public async Task<Coordenador> ConsultarPeloCpfAsync(string cpfDoCoordenador)
        {
            return await _coordenadorService.ConsultarPeloCpfAsync(cpfDoCoordenador);
        }
    }
}