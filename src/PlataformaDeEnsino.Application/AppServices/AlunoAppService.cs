using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class AlunoAppService : AppServiceBase<Aluno, int>, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;
        public AlunoAppService(IAlunoService alunoService) : base(alunoService)
        {
            _alunoService = alunoService;
        }
    }
}