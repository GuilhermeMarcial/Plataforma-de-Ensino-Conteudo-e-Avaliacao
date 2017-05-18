using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class UnidadeService : ServiceBase<Unidade>, IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;
        public UnidadeService(IUnidadeRepository unidadeRepository) : base(unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public async Task<IEnumerable<Unidade>> ConsultarUnidadadesDoModuloAsync(int idDoModulo)
        {
            return await _unidadeRepository.ConsultarUnidadadesDoModuloAsync(idDoModulo);
        }
        public async Task<IEnumerable<Unidade>> ConsultarUnidadesDoProfessorAsync(int idDoProfessor)
        {
            return await _unidadeRepository.ConsultarUnidadesDoProfessorAsync(idDoProfessor);
        }
    }
}