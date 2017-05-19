using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    [Route("Professor")]
    [AutoValidateAntiforgeryToken]
    public class ProfessorController : Controller
    {
        private UrlEncoder _encoder;
        private IEnumerable<FileInfo> arquivos;
        private readonly IMapper _mapper;
        private readonly IProfessorAppService _professorAppService;
        private readonly IModuloAppService _moduloAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IRecuperarArquivosAppService _arquivoAppService;
        private readonly IDelecaoDeArquivosAppService _deletarAppService;
        private readonly IEnviarArquivosAppService _enviarAquivoAppService;
        private Professor _professorUsuario;

        public ProfessorController(IMapper mapper, IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService, IRecuperarArquivosAppService arquivoAppService, IDelecaoDeArquivosAppService deletarAppService, IEnviarArquivosAppService enviarAquivoAppService, IProfessorAppService professorAppService)
        {
            _mapper = mapper;
            _professorAppService = professorAppService;
            _moduloAppService = moduloAppService;
            _unidadeAppService = unidadeAppService;
            _arquivoAppService = arquivoAppService;
            _deletarAppService = deletarAppService;
            _enviarAquivoAppService = enviarAquivoAppService;
            _encoder = UrlEncoder.Create();
        }

        private async Task<Professor> ProfessorUsuario()
        {
            return await _professorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        [HttpGet("EnviarArquivo")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> SelecionarArquivoProfessor()
        {
            var professorUsuario = ProfessorUsuario();
            _professorUsuario = await _professorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
            
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadesDoProfessorAsync(_professorUsuario.IdDoProfessor));
            var ConteudoProfessorViewModel = new ConteudoProfessorViewModel(unidadeViewModel);
            return View(ConteudoProfessorViewModel);
        }

        [HttpGet("Conteudo")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> ConteudoProfessor([FromQuery] string diretorioDaUnidade)
        {
            var professorUsuario = ProfessorUsuario();
            _professorUsuario = await ProfessorUsuario();
            
            ViewBag.UserName = _professorUsuario.NomeDoProfessor + " " + _professorUsuario.SobrenomeDoProfessor;
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadesDoProfessorAsync(_professorUsuario.IdDoProfessor));
            arquivos = diretorioDaUnidade != null ? await _arquivoAppService.RecuperarArquivosAsync(diretorioDaUnidade) : null;
            var ConteudoProfessorViewModel = new ConteudoProfessorViewModel(unidadeViewModel, arquivos);
            return View(ConteudoProfessorViewModel);
        }

        [HttpPost("EnviarArquivo")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> SelecionarArquivoProfessor(string diretorioDaUnidade, IFormFile arquivo)
        {
            string urlEncode;
            if (diretorioDaUnidade != null)
            {
                urlEncode = _encoder.Encode(diretorioDaUnidade);
                await _enviarAquivoAppService.EnviarArquivos(diretorioDaUnidade, arquivo);
                return Redirect("Conteudo?DiretorioDaUnidade=" + urlEncode);
            }
            return Redirect("Conteudo");
        }

        [HttpGet("Download")]
        [Authorize(Roles = "Professor")]
        public FileResult DownloadFile(string caminhoDoArquivo)
        {
            var file = new FileInfo(caminhoDoArquivo);
            byte[] fileBytes = System.IO.File.ReadAllBytes(file.FullName);
            return File(fileBytes, "application/pdf", file.Name);
        }

        [HttpGet("Deletar")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> DeletarArquivo(string caminhoDoArquivo, string nomeDoArquivo)
        {
            await Task.Run(() => _deletarAppService.DeletarArquivoAsync(caminhoDoArquivo));

            var caminhoDoDiretorio = caminhoDoArquivo.Replace(nomeDoArquivo, "");
            var urlEncode = _encoder.Encode(caminhoDoDiretorio);
            return Redirect("Conteudo?DiretorioDaUnidade=" + urlEncode);
        }
    }
}