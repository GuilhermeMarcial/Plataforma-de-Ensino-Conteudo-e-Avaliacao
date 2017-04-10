using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class AlunoService : ServiceBase<Aluno, int>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository) : base(alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
    }
}