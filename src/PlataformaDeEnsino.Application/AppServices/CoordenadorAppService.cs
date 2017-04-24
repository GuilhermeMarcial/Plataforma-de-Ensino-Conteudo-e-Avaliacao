using System;
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

        public Coordenador ConsultarPeloCpf(string cpfDoCoordenador)
        {
            return _coordenadorService.ConsultarPeloCpf(cpfDoCoordenador);
        }
    }
}