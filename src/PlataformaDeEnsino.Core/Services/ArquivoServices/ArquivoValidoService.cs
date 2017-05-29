using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class ArquivoValidoService : IArquivoValidoService
    {
        private readonly IDiretorioExisteService _diretorioExisteService;
        private readonly ITamanhoDoArquivoValidoService _tamanhoDoArquivoValidoService;
        private readonly IExtesaoValidaDoArquivoService _extesaoValidaDoArquivoService;
        private readonly IArquivoNulloOuVazioService _arquivoNulloOuVazio;

        public ArquivoValidoService(IDiretorioExisteService diretorioExisteService, IArquivoNulloOuVazioService arquivoNulloOuVazio, 
            ITamanhoDoArquivoValidoService tamanhoDoArquivoValidoService, IExtesaoValidaDoArquivoService extesaoValidaDoArquivoService)
        {
            _diretorioExisteService = diretorioExisteService;
            _tamanhoDoArquivoValidoService = tamanhoDoArquivoValidoService;
            _arquivoNulloOuVazio = arquivoNulloOuVazio;
            _extesaoValidaDoArquivoService = extesaoValidaDoArquivoService;
        }

        public async Task<bool> ArquivoValido(string caminhoDoArquivo, IFormFile file)
        {
            if (!_diretorioExisteService.DiretorioExiste(caminhoDoArquivo)) return false;
            if (_arquivoNulloOuVazio.ArquivoNulloOuVazio(file) && _tamanhoDoArquivoValidoService.TamanhoDoArquivoValido(file))
            {
                return await _extesaoValidaDoArquivoService.ExtensaoValidaDoArquivo(file);   
            }

            return false;
        }
    }
}