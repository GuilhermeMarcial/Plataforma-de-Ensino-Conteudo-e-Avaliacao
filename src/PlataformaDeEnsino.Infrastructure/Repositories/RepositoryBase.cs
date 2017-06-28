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
        protected ConteudoDbContext context = new ConteudoDbContext();
        
        public void AtualizarAsync(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task<TEntity> ConsultarPeloIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ConsultarTodosAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async void DeletarAsync(int id)
        {
            TEntity obj = await context.Set<TEntity>().FindAsync(id);
            context.Set<TEntity>().Remove(obj);
            context.SaveChanges();
        }

        public async void InserirAsync(TEntity obj)
        {
            await context.Set<TEntity>().AddAsync(obj);
            context.SaveChanges();
        }
    }
}