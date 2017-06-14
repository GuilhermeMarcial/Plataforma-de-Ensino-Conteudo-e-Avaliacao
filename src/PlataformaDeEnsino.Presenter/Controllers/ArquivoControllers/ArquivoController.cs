using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Presenter.Controllers.ArquivoControllers
{
    [Route("Aluno")]
    [Route("Professor")]
    [Route("Coordenador")]
    public class ArquivoController : Controller
    {
        private readonly ILerArquivoAppService _lerArquivoAppService;
        private readonly IDelecaoDeArquivosAppService _deletarArquivoAppService;
        private readonly UrlEncoder _encoder;
        private readonly ILerArquivoEmBytesAppService _lerArquivoEmBytesAppService;

        public ArquivoController(ILerArquivoAppService lerArquivoAppService, IDelecaoDeArquivosAppService deletarArquivoAppService, UrlEncoder encoder, ILerArquivoEmBytesAppService lerArquivoEmBytesAppService)
        {
            _lerArquivoAppService = lerArquivoAppService;
            _deletarArquivoAppService = deletarArquivoAppService;
            _encoder = encoder;
            _lerArquivoEmBytesAppService = lerArquivoEmBytesAppService;
        }

        [HttpGet("Download")]
        [Authorize]
        public FileResult DownloadFile(string caminhoDoArquivo)
        {
            var file = _lerArquivoAppService.LerArquivo(caminhoDoArquivo);
            var fileBytes = _lerArquivoEmBytesAppService.LerArquivoEmBytes(file);
            return File(fileBytes, "application/pdf", file.Name);
        }
        
        [HttpGet("Deletar")]
        [Authorize(Roles = "Coordenador, Professor")]
        public async Task<IActionResult> DeletarArquivo(string caminhoDoArquivo, string nomeDoArquivo)
        {
            await Task.Run(() => _deletarArquivoAppService.DeletarArquivoAsync(caminhoDoArquivo));

            var caminhoDoDiretorio = caminhoDoArquivo.Replace(nomeDoArquivo, "");
            var urlEncode = _encoder.Encode(caminhoDoDiretorio);
            return Redirect("Conteudo?DiretorioDaUnidade=" + urlEncode);
        }
    }
}