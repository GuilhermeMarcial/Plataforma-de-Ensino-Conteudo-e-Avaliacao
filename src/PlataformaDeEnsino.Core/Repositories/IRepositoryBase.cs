using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Repositories
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class where TKey : struct
    {
        IEnumerable<TEntity> ConsultarTodos();
        TEntity ConsultarPeloId(TKey id);
        void Inserir(TEntity obj);
        void Deletar(TKey id);
        void Atualizar(TEntity obj);
        void Dispose();

    }
}