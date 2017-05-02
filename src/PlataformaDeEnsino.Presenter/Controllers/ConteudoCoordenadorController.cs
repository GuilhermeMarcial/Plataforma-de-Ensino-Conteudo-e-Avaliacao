using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
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
    public class ConteudoCoordenadorController : Controller
    {
        private IEnumerable<FileInfo> arquivos;
        private UrlEncoder _encoder;
        private readonly IMapper _mapper;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IModuloAppService _moduloAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IRecuperarArquivosAppService _arquivoAppService;
        private readonly IDelecaoDeArquivosAppService _deletarAppService;
        private readonly IEnviarArquivosAppService _enviarAquivoAppService;
        private Coordenador _coordenadorUsuario;

        public ConteudoCoordenadorController(IMapper mapper, IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService, 
        IRecuperarArquivosAppService arquivoAppService, IDelecaoDeArquivosAppService deletarAppService, 
        IEnviarArquivosAppService enviarAquivoAppService, ICoordenadorAppService coordenadorAppService)
        {
            _mapper = mapper;
            _moduloAppService = moduloAppService;
            _unidadeAppService = unidadeAppService;
            _arquivoAppService = arquivoAppService;
            _deletarAppService = deletarAppService;
            _enviarAquivoAppService = enviarAquivoAppService;
            _coordenadorAppService = coordenadorAppService;
            _encoder = UrlEncoder.Create();
        }

        private Coordenador CoodernadorUsuario()
        {
            return _coordenadorAppService.ConsultarPeloCpf(User.Identity.Name);
        }

        [HttpGet("ConteudoCoordenador")]
        [Authorize(Roles = "Coordenador")]
        public IActionResult ConteudoCoordenador([FromQuery] int idDoModulo, string DiretorioDaUnidade)
        {
            _coordenadorUsuario = CoodernadorUsuario();
            ViewBag.UserName = _coordenadorUsuario.NomeDoCoordenador + " " + _coordenadorUsuario.SobrenomeDoCoordenador;
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(_moduloAppService.ConsultarModulosDoCurso(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(_unidadeAppService.ConsultarUnidadadesDoModulo(idDoModulo));
            arquivos = DiretorioDaUnidade != null ? _arquivoAppService.RecuperarArquivos(DiretorioDaUnidade) : null;
            var ConteudoAlunoViewModel = new ConteudoAlunoViewModel(moduloViewModel, unidadeViewModel, arquivos);
            return View(ConteudoAlunoViewModel);
        }

        [HttpGet("SelecionarConteudoCoordenador")]
        [Authorize(Roles = "Coordenador")]
        public ViewResult SelecionarConteudoCoordenador(int idDoModulo)
        {
            _coordenadorUsuario = CoodernadorUsuario();
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(_moduloAppService.ConsultarModulosDoCurso(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(_unidadeAppService.ConsultarUnidadadesDoModulo(idDoModulo));
            var ConteudoAlunoViewModel = new ConteudoAlunoViewModel(moduloViewModel, unidadeViewModel);
            return View(ConteudoAlunoViewModel);
        }

        [HttpPost("SelecionarConteudoCoordenador")]
        [Authorize(Roles = "Coordenador")]
        public async Task<IActionResult> SelecionarArquivoCoordenador(string diretorioDaUnidade, IFormFile arquivo)
        {
            string urlEncode;
            if (diretorioDaUnidade != null)
            {
                urlEncode = _encoder.Encode(diretorioDaUnidade);
                await _enviarAquivoAppService.EnviarArquivos(diretorioDaUnidade, arquivo);
                return Redirect("ConteudoCoordenador?DiretorioDaUnidade=" + urlEncode);
            }
            return Redirect("ConteudoCoordenador");
        }

        [HttpGet("DownloadCoordenador")]
        [Authorize(Roles = "Coordenador")]
        public FileResult DownloadFile(string caminhoDoArquivo)
        {
            var file = new FileInfo(caminhoDoArquivo);
            byte[] fileBytes = System.IO.File.ReadAllBytes(file.FullName);
            return File(fileBytes, "application/pdf", file.Name);
        }

        [HttpGet("DeletarCoordenador")]
        [Authorize(Roles = "Coordenador")]
        public IActionResult DeletarArquivo(string caminhoDoArquivo)
        {
            var urlEncode = _encoder.Encode(caminhoDoArquivo);
            _deletarAppService.DeletarArquivo(caminhoDoArquivo);
            return Redirect("ConteudoCoordenador?DiretorioDaUnidade=" + urlEncode);
        }
    }
}