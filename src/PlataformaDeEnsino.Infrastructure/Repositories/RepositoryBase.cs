using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Infrastructure.Context;
using System;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected ConteudoDbContext Context = new ConteudoDbContext();

        public void Atualizar(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public TEntity ConsultarPeloId(int id)
        {


            return Context.Set<TEntity>().Find(id);

        }

        public IEnumerable<TEntity> ConsultarTodos()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Deletar(int id)
        {

            TEntity obj = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(obj);
            Context.Commit();
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Inserir(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
            Context.SaveChanges();
        }
    }
}