using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    [Route("Professor")]
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
    public class ProfessorController : Controller
    {
        private UrlEncoder _encoder;
        private Professor _professorUsuario;
        private IEnumerable<FileInfo> arquivos;
        private readonly IMapper _mapper;
        private readonly IProfessorAppService _professorAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly ILerArquivoEmBytesAppService _lerArquivoEmBytesAppService;
        private readonly ILerArquivoAppService _lerArquivoAppService;
        private readonly IRecuperarArquivosAppService _arquivoAppService;
        private readonly IDelecaoDeArquivosAppService _deletarAppService;
        private readonly IEnviarArquivosAppService _enviarAquivoAppService;

        public ProfessorController(IMapper mapper, IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService, IRecuperarArquivosAppService arquivoAppService, IDelecaoDeArquivosAppService deletarAppService, 
            IEnviarArquivosAppService enviarAquivoAppService, IProfessorAppService professorAppService, ILerArquivoAppService lerArquivoAppService, ILerArquivoEmBytesAppService lerArquivoEmBytesAppService)
        {
            _mapper = mapper;
            _professorAppService = professorAppService;
            _unidadeAppService = unidadeAppService;
            _arquivoAppService = arquivoAppService;
            _deletarAppService = deletarAppService;
            _enviarAquivoAppService = enviarAquivoAppService;
            _lerArquivoAppService = lerArquivoAppService;
            _lerArquivoEmBytesAppService = lerArquivoEmBytesAppService;
            _encoder = UrlEncoder.Create();
        }

        private async Task<Professor> ProfessorUsuario()
        {
            return await _professorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        [HttpGet("EnviarArquivo")]
        public async Task<IActionResult> SelecionarArquivoProfessor()
        {
            var professorUsuario = ProfessorUsuario();
            _professorUsuario = await _professorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
            
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadesDoProfessorAsync(_professorUsuario.IdDoProfessor));
            var conteudoProfessorViewModel = new ConteudoProfessorViewModel(unidadeViewModel);
            return View(conteudoProfessorViewModel);
        }

        [HttpGet("Conteudo")]
        public async Task<IActionResult> ConteudoProfessor([FromQuery] string diretorioDaUnidade)
        {
            var professorUsuario = ProfessorUsuario();
            _professorUsuario = await professorUsuario;
            
            ViewBag.UserName = _professorUsuario.NomeDoProfessor + " " + _professorUsuario.SobrenomeDoProfessor;
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadesDoProfessorAsync(_professorUsuario.IdDoProfessor));
            arquivos = diretorioDaUnidade != null ? await _arquivoAppService.RecuperarArquivosAsync(diretorioDaUnidade) : null;
            var conteudoProfessorViewModel = new ConteudoProfessorViewModel(unidadeViewModel, arquivos);
            return View(conteudoProfessorViewModel);
        }

        [HttpPost("EnviarArquivo")]
        public async Task<IActionResult> SelecionarArquivoProfessor(string diretorioDaUnidade, IFormFile arquivo)
        {
            if (diretorioDaUnidade == null) return Redirect("Conteudo");
            var urlEncode = _encoder.Encode(diretorioDaUnidade);
            await _enviarAquivoAppService.EnviarArquivos(diretorioDaUnidade, arquivo);
            return Redirect("Conteudo?DiretorioDaUnidade=" + urlEncode);
        }

        [HttpGet("Download")]
        public FileResult DownloadFile(string caminhoDoArquivo)
        {
            var file = _lerArquivoAppService.LerArquivoApp(caminhoDoArquivo);
            var fileBytes = _lerArquivoEmBytesAppService.LerArquivoEmBytes(file);
            return File(fileBytes, "application/pdf", file.Name);
        }

        [HttpGet("Deletar")]
        public async Task<IActionResult> DeletarArquivo(string caminhoDoArquivo, string nomeDoArquivo)
        {
            await Task.Run(() => _deletarAppService.DeletarArquivoAsync(caminhoDoArquivo));

            var caminhoDoDiretorio = caminhoDoArquivo.Replace(nomeDoArquivo, "");
            var urlEncode = _encoder.Encode(caminhoDoDiretorio);
            return Redirect("Conteudo?DiretorioDaUnidade=" + urlEncode);
        }
    }
}