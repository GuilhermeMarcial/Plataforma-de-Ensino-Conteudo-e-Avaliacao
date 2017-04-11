using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Services.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ConsultarTodos();
        TEntity ConsultarPeloId(int id);
        void Inserir(TEntity obj);
        void Deletar(int id);
        void Atualizar(TEntity obj);
        void Dispose();
    }
}