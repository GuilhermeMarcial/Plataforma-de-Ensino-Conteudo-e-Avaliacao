using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class UnidadeService : ServiceBase<Unidade, int>, IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;
        public UnidadeService(IUnidadeRepository unidadeRepository) : base(unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }
    }
}