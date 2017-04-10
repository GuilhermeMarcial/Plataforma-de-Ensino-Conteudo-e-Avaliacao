using System;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class ServiceBase<TEntity, TKey> : IServiceBase<TEntity, TKey> where TEntity : class where TKey : struct
    {
        private readonly IRepositoryBase<TEntity,TKey> _repository;
        public ServiceBase(IRepositoryBase<TEntity, TKey> repository)
        {
            _repository = repository;
        }
        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public TEntity ConsultarPeloId(TKey id)
        {
            return _repository.ConsultarPeloId(id);
        }

        public IEnumerable<TEntity> ConsultarTodos()
        {
            return _repository.ConsultarTodos();
        }

        public void Deletar(TKey id)
        {
            _repository.Deletar(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void Inserir(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}