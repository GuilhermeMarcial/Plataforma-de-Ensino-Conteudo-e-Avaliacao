using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class TurmaService : ServiceBase<Turma, int>, ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        public TurmaService(ITurmaRepository turmaRepository) : base(turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }
    }
}