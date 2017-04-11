using System.Collections.Generic;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }
        public TEntity ConsultarPeloId(int id)
        {
            return _repository.ConsultarPeloId(id);
        }

        public IEnumerable<TEntity> ConsultarTodos()
        {
            return _repository.ConsultarTodos();
        }

        public void Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void Inserir(TEntity obj)
        {
            _repository.Inserir(obj);
        }
    }
}