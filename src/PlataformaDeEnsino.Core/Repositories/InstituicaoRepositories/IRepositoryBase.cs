using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ConsultarTodosAsync();
        Task<TEntity> ConsultarPeloIdAsync(int id);
        void InserirAsync(TEntity obj);
        void DeletarAsync(int id);
        void AtualizarAsync(TEntity obj);
    }
}