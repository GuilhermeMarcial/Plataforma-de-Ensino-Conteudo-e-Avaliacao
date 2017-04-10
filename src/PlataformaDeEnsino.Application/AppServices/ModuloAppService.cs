using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class ModuloAppService : AppServiceBase<Modulo, int>, IModuloAppService
    {
        private readonly IModuloService _moduloService;
        public ModuloAppService(IModuloService moduloService) : base(moduloService)
        {
            _moduloService = moduloService;
        }
    }
}