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
        public IEnumerable<Modulo> ConsultarModulosDoCurso(int idDoCurso)
        {
            return  _moduloService.ConsultarModulosDoCurso(idDoCurso);
        }
        public IEnumerable<Modulo> ConsultarModulosDoCurso(int idDoCurso, int nivelDoAluno)
        {
            return  _moduloService.ConsultarModulosDoCurso(idDoCurso, nivelDoAluno);
        }
    }
}