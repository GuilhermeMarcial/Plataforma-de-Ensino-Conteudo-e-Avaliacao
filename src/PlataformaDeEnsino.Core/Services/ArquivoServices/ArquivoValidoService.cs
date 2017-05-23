using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class ArquivoValidoService : IArquivoValidoService
    {
        private readonly IDiretorioExisteService _diretorioExisteService;
        private readonly IArquivoNulloOuVazioService _arquivoNulloOuVazioService;
        private readonly ITamanhoDoArquivoValidoService _tamanhoDoArquivoValidoService;
        private readonly IExtesaoValidaDoArquivoService _extesaoValidaDoArquivoService;

        public ArquivoValidoService(IDiretorioExisteService diretorioExisteService, IArquivoNulloOuVazioService arquivoNulloOuVazioService, ITamanhoDoArquivoValidoService tamanhoDoArquivoValidoService, IExtesaoValidaDoArquivoService extesaoValidaDoArquivoService)
        {
            _diretorioExisteService = diretorioExisteService;
            _arquivoNulloOuVazioService = arquivoNulloOuVazioService;
            _tamanhoDoArquivoValidoService = tamanhoDoArquivoValidoService;
            _extesaoValidaDoArquivoService = extesaoValidaDoArquivoService;
        }

        public async Task<bool> ArquivoValido(string caminhoDoArquivo, IFormFile file)
        {
            if (!_diretorioExisteService.DiretorioExiste(caminhoDoArquivo)) return false;
            if ((!_arquivoNulloOuVazioService.ArquivoNulloOuVazio(file)) ||
                (!_tamanhoDoArquivoValidoService.TamanhoDoArquivoValido(file))) return false;
            return await _extesaoValidaDoArquivoService.ExtensaoValidaDoArquivo(file);
        }
    }
}