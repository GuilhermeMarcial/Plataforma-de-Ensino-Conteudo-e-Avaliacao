using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Core.Services.InstituicaoServices
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public void AtualizarAsync(TEntity obj)
        {
            _repository.AtualizarAsync(obj);
        }
        public async Task<TEntity> ConsultarPeloIdAsync(int id)
        {
            return await _repository.ConsultarPeloIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ConsultarTodosAsync()
        {
            return await _repository.ConsultarTodosAsync();
        }

        public void DeletarAsync(int id)
        {
             _repository.DeletarAsync(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void InserirAsync(TEntity obj)
        {
            _repository.InserirAsync(obj);
        }
    }
}