using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Core.Services.InstituicaoServices
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