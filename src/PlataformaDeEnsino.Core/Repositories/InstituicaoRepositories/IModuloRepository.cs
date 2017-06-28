using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories
{
    public interface IModuloRepository : IRepositoryBase<Modulo>
    {
        Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDoCurso);
        Task<IEnumerable<Modulo>> ConsultarModulosDoCursoAsync(int idDaTurma, int nivelDoAluno);
    }
}