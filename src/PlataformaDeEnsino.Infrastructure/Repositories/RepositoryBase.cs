using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Infrastructure.Context;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class where TKey : struct
    {
        protected readonly ConteudoDbContext Context;
        
        public void Atualizar(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            Context.Commit();
        }

        public TEntity ConsultarPeloId(TKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ConsultarTodos()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Deletar(TKey id)
        {
            TEntity obj = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(obj);
            Context.Commit();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Inserir(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
            Context.SaveChanges();
        }
    }
}