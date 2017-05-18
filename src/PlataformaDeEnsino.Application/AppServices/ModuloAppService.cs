using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class ModuloAppService : AppServiceBase<Modulo>, IModuloAppService
    {
        private readonly IModuloService _moduloService;
        public ModuloAppService(IModuloService moduloService) : base(moduloService)
        {
            _moduloService = moduloService;
        }
        public async Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso)
        {
            return await _moduloService.ConsultarModulosDoCursoAsync(idDoCurso);
        }
        public async Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso, int nivelDoAluno)
        {
            return await _moduloService.ConsultarModulosDoCursoAsync(idDoCurso, nivelDoAluno);
        }
    }
}