using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class TurmaAppService : AppServiceBase<Turma>, ITurmaAppService
    {
        private readonly ITurmaService _turmaService;
        public TurmaAppService(ITurmaService turmaService) : base(turmaService)
        {
            _turmaService = turmaService;
        }
    }
}