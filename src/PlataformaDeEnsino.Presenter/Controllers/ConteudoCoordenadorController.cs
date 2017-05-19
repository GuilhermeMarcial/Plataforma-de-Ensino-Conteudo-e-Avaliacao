using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
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

        private async Task<Coordenador> CoodernadorUsuario()
        {
            return await _coordenadorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        [HttpGet("ConteudoCoordenador")]
        public async Task<IActionResult> ConteudoCoordenador([FromQuery] int idDoModulo, string DiretorioDaUnidade)
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;
            
            ViewBag.UserName = _coordenadorUsuario.NomeDoCoordenador + " " + _coordenadorUsuario.SobrenomeDoCoordenador;
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            arquivos = DiretorioDaUnidade != null ? await _arquivoAppService.RecuperarArquivosAsync(DiretorioDaUnidade) : null;
            var ConteudoAlunoViewModel = new ConteudoAlunoViewModel(moduloViewModel, unidadeViewModel, arquivos);
            return View(ConteudoAlunoViewModel);
        }

        [HttpGet("SelecionarConteudoCoordenador")]
        public async Task<ViewResult> SelecionarConteudoCoordenador(int idDoModulo)
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            var ConteudoAlunoViewModel = new ConteudoAlunoViewModel(moduloViewModel, unidadeViewModel);
            return View(ConteudoAlunoViewModel);
        }

        [HttpPost("SelecionarConteudoCoordenador")]
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
        public FileResult DownloadFile(string caminhoDoArquivo)
        {
            var file = new FileInfo(caminhoDoArquivo);
            byte[] fileBytes = System.IO.File.ReadAllBytes(file.FullName);
            return File(fileBytes, "application/pdf", file.Name);
        }

        [HttpGet("DeletarCoordenador")]
        public async Task<IActionResult> DeletarArquivo(string caminhoDoArquivo, string nomeDoArquivo)
        {
            await Task.Run(() => _deletarAppService.DeletarArquivoAsync(caminhoDoArquivo));

            var caminhoDoDiretorio = caminhoDoArquivo.Replace(nomeDoArquivo, "");
            var urlEncode = _encoder.Encode(caminhoDoDiretorio);
            return Redirect("ConteudoCoordenador?DiretorioDaUnidade=" + urlEncode);
        }
    }
}