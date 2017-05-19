using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.InstituicaoAppServices
{
    public class UnidadeAppService : AppServiceBase<Unidade>, IUnidadeAppService
    {
        private readonly IUnidadeService _unidadeService;

        public UnidadeAppService(IUnidadeService unidadeService) : base(unidadeService)
        {
            _unidadeService = unidadeService;
        }

        public async Task<IEnumerable<Unidade>> ConsultarUnidadadesDoModuloAsync(int idDoModulo)
        {
            return await _unidadeService.ConsultarUnidadadesDoModuloAsync(idDoModulo);
        }
        public async Task<IEnumerable<Unidade>> ConsultarUnidadesDoProfessorAsync(int idDoProfessor)
        {
            return await _unidadeService.ConsultarUnidadesDoProfessorAsync(idDoProfessor);
        }
    }
}