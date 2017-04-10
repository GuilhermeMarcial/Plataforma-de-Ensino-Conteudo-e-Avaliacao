using System.Collections.Generic;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class AppServiceBase<TEntity, TKey> : IAppServiceBase<TEntity, TKey> where TEntity : class where TKey : struct
    {
        private readonly IServiceBase<TEntity, TKey> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity, TKey> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Atualizar(TEntity obj)
        {
            _serviceBase.Atualizar(obj);
        }

        public TEntity ConsultarPeloId(TKey id)
        {
            return _serviceBase.ConsultarPeloId(id);
        }

        public IEnumerable<TEntity> ConsultarTodos()
        {
            return _serviceBase.ConsultarTodos();
        }

        public void Deletar(TKey id)
        {
            _serviceBase.Deletar(id);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public void Inserir(TEntity obj)
        {
            _serviceBase.Inserir(obj);
        }
    }
}