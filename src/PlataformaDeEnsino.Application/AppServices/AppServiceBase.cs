using System.Collections.Generic;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Atualizar(TEntity obj)
        {
            _serviceBase.Atualizar(obj);
        }

        public TEntity ConsultarPeloId(int id)
        {
            return _serviceBase.ConsultarPeloId(id);
        }

        public IEnumerable<TEntity> ConsultarTodos()
        {
            return _serviceBase.ConsultarTodos();
        }

        public void Deletar(int id)
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