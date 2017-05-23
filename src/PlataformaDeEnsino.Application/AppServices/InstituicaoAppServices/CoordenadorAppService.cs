using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.InstituicaoAppServices
{
    public class CoordenadorAppService : AppServiceBase<Coordenador>, ICoordenadorAppService
    {
        private readonly ICoordenadorService _coordenadorService;
        public CoordenadorAppService(ICoordenadorService coordenadorService) : base(coordenadorService)
        {
            _coordenadorService = coordenadorService;
        }

        public async Task<Coordenador> ConsultarPeloCpfAsync(string cpfDaPessoa)
        {
            return await _coordenadorService.ConsultarPeloCpfAsync(cpfDaPessoa);
        }
    }
}