using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.Areas.Professores.ViewModels;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Areas.Professores.Controllers
{
    [Area("Professores")]
    [Route("Professor")]
    [Authorize(Roles = "Professor")]
    [AutoValidateAntiforgeryToken]
    public class ProfessorController : Controller
    {
        private readonly UrlEncoder _encoder;
        private Professor _professorUsuario;
        private IEnumerable<FileInfo> _arquivos;
        private readonly IMapper _mapper;
        private readonly IProfessorAppService _professorAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IRecuperarArquivosAppService _arquivoAppService;
        private readonly IEnviarArquivosAppService _enviarAquivoAppService;

        public ProfessorController(IMapper mapper, IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService, IRecuperarArquivosAppService arquivoAppService, IDelecaoDeArquivosAppService deletarAppService, 
            IEnviarArquivosAppService enviarAquivoAppService, IProfessorAppService professorAppService, ILerArquivoAppService lerArquivoAppService, ILerArquivoEmBytesAppService lerArquivoEmBytesAppService)
        {
            _mapper = mapper;
            _professorAppService = professorAppService;
            _unidadeAppService = unidadeAppService;
            _arquivoAppService = arquivoAppService;
            _enviarAquivoAppService = enviarAquivoAppService;
            _encoder = UrlEncoder.Create();
        }

        private async Task<Professor> ProfessorUsuario()
        {
            return await _professorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        [HttpGet("SelecionarArquivo")]
        public async Task<IActionResult> SelecionarArquivoProfessor()
        {
            var professorUsuario = ProfessorUsuario();
            _professorUsuario = await professorUsuario;
            
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadesDoProfessorAsync(_professorUsuario.IdDoProfessor));
            var conteudoProfessorViewModel = new ConteudoProfessorViewModel(unidadeViewModel);
            return View(conteudoProfessorViewModel);
        }

        [HttpGet("Conteudo")]
        public async Task<IActionResult> ConteudoProfessor(string diretorioDaUnidade)
        {
            var professorUsuario = ProfessorUsuario();
            _professorUsuario = await professorUsuario;
            
            ViewBag.UserName = _professorUsuario.NomeDaPessoa + " " + _professorUsuario.SobrenomeDaPessoa;
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadesDoProfessorAsync(_professorUsuario.IdDoProfessor));
            _arquivos = diretorioDaUnidade != null ? await _arquivoAppService.RecuperarArquivosAsync(diretorioDaUnidade) : null;
            var conteudoProfessorViewModel = new ConteudoProfessorViewModel(unidadeViewModel, _arquivos);
            return View(conteudoProfessorViewModel);
        }

        [HttpPost("SelecionarArquivo")]
        public async Task<IActionResult> EnviarArquivoProfessor(string diretorioDaUnidade, IFormFile arquivo)
        {
            if ((diretorioDaUnidade == null) || (arquivo == null))  return Redirect("SelecionarConteudoCoordenador");
            var urlEncode = _encoder.Encode(diretorioDaUnidade);
            await _enviarAquivoAppService.EnviarArquivos(diretorioDaUnidade, arquivo);
            return Redirect("Conteudo?DiretorioDaUnidade=" + urlEncode);
        }
    }
}