using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces
{
    public interface IModuloService : IServiceBase<Modulo>
    {
        Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso);
        Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso, int nivelDoAluno);
    }
}