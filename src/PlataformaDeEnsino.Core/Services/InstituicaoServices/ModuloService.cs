using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Core.Services.InstituicaoServices
{
    public class ModuloService : ServiceBase<Modulo>, IModuloService
    {
        private readonly IModuloRepository _moduloRepository;

        public ModuloService(IModuloRepository moduloRepository) : base(moduloRepository)
        {
            _moduloRepository = moduloRepository;
        }
        public async Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso)
        {
            return await _moduloRepository.ConsultarModulosDoCursoAsync(idDoCurso);
        }
        public async Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso, int nivelDoAluno)
        {
            return await _moduloRepository.ConsultarModulosDoCursoAsync(idDoCurso, nivelDoAluno);
        }
    }
}