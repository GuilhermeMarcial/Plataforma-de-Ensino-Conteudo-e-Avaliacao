using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Infrastructure.Context;
using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected ConteudoDbContext Context = new ConteudoDbContext();

        public void AtualizarAsync(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public async Task<TEntity> ConsultarPeloIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ConsultarTodosAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async void DeletarAsync(int id)
        {

            TEntity obj = await Context.Set<TEntity>().FindAsync(id);
            Context.Set<TEntity>().Remove(obj);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async void InserirAsync(TEntity obj)
        {
            await Context.Set<TEntity>().AddAsync(obj);
            Context.SaveChanges();
        }
    }
}