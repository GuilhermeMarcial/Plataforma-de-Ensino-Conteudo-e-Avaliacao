using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Infrastructure.Context;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class where TKey : struct
    {
        protected ConteudoContext context;

        public void Atualizar(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.Commit();
        }

        public TEntity ConsultarPeloId(TKey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ConsultarTodos()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Deletar(TKey id)
        {
            TEntity obj = context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Remove(obj);
            context.Commit();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Inserir(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
            context.SaveChanges();
        }
    }
}