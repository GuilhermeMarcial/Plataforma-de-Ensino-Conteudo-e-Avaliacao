using System;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface IUnidadeRepository : IRepositoryBase<Unidade>, IDisposable
    {
         IEnumerable<Unidade> ConsultarUnidadadesDoModulo(int idDoModulo);

         IEnumerable<Unidade> ConsultarUnidadesDoProfessor(int idDoProfessor);
    }
}