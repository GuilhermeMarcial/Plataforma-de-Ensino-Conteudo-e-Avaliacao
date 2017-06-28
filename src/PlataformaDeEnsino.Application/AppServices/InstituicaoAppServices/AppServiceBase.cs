using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.InstituicaoAppServices
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void AtualizarAsync(TEntity obj)
        {
            _serviceBase.AtualizarAsync(obj);
        }

        public async Task<TEntity> ConsultarPeloIdAsync(int id)
        {
            return await _serviceBase.ConsultarPeloIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ConsultarTodosAsync()
        {
            return await _serviceBase.ConsultarTodosAsync();
        }

        public void DeletarAsync(int id)
        {
            _serviceBase.DeletarAsync(id);
        }
        
        public void InserirAsync(TEntity obj)
        {
            _serviceBase.InserirAsync(obj);
        }
    }
}