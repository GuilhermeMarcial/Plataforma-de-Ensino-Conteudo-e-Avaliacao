using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
    public class ConteudoCoordenadorController : Controller
    {
        private IEnumerable<FileInfo> _arquivos;
        private readonly UrlEncoder _encoder;
        private readonly IMapper _mapper;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IModuloAppService _moduloAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IRecuperarArquivosAppService _recuperarArquivoAppService;
        private readonly IDelecaoDeArquivosAppService _deletarArquivoAppService;
        private readonly IEnviarArquivosAppService _enviarArquivoAppService;
        private Coordenador _coordenadorUsuario;
        private ILerArquivoAppService _lerArquivoAppService;
        private ILerArquivoEmBytesAppService _lerArquivoEmBytesAppService;


        public ConteudoCoordenadorController(IMapper mapper, IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService, 
        IRecuperarArquivosAppService recuperarArquivoAppService, IDelecaoDeArquivosAppService deletarArquivoAppService, 
        IEnviarArquivosAppService enviarArquivoAppService, ICoordenadorAppService coordenadorAppService, ILerArquivoEmBytesAppService lerArquivoEmBytesAppService
        , ILerArquivoAppService lerArquivoAppService)
        {
            _mapper = mapper;
            _moduloAppService = moduloAppService;
            _unidadeAppService = unidadeAppService;
            _recuperarArquivoAppService = recuperarArquivoAppService;
            _deletarArquivoAppService = deletarArquivoAppService;
            _enviarArquivoAppService = enviarArquivoAppService;
            _coordenadorAppService = coordenadorAppService;
            _lerArquivoAppService = lerArquivoAppService;
            _lerArquivoEmBytesAppService = lerArquivoEmBytesAppService;
            _encoder = UrlEncoder.Create();
            
        }

        private async Task<Coordenador> CoodernadorUsuario()
        {
            return await _coordenadorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        [HttpGet("ConteudoCoordenador")]
        public async Task<IActionResult> ConteudoCoordenador([FromQuery] int idDoModulo, string diretorioDaUnidade)
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;
            
            ViewBag.UserName = _coordenadorUsuario.NomeDoCoordenador + " " + _coordenadorUsuario.SobrenomeDoCoordenador;
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            _arquivos = diretorioDaUnidade != null ? await _recuperarArquivoAppService.RecuperarArquivosAsync(diretorioDaUnidade) : null;
            var conteudoAlunoViewModel = new ConteudoAlunoViewModel(moduloViewModel, unidadeViewModel, _arquivos);
            return View(conteudoAlunoViewModel);
        }

        [HttpGet("SelecionarConteudoCoordenador")]
        public async Task<ViewResult> SelecionarConteudoCoordenador(int idDoModulo)
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            var conteudoAlunoViewModel = new ConteudoAlunoViewModel(moduloViewModel, unidadeViewModel);
            return View(conteudoAlunoViewModel);
        }

        [HttpPost("SelecionarConteudoCoordenador")]
        public async Task<IActionResult> SelecionarArquivoCoordenador(string diretorioDaUnidade, IFormFile arquivo)
        {
            if (diretorioDaUnidade != null)
            {
                var urlEncode = _encoder.Encode(diretorioDaUnidade);
                await _enviarArquivoAppService.EnviarArquivos(diretorioDaUnidade, arquivo);
                return Redirect("ConteudoCoordenador?DiretorioDaUnidade=" + urlEncode);
            }
            return Redirect("ConteudoCoordenador");
        }

        [HttpGet("DownloadCoordenador")]
        public FileResult DownloadFile(string caminhoDoArquivo)
        {
            var file = _lerArquivoAppService.LerArquivoApp(caminhoDoArquivo);
            var fileBytes = _lerArquivoEmBytesAppService.LerArquivoEmBytes(file);
            return File(fileBytes, "application/pdf", file.Name);
        }

        [HttpGet("DeletarCoordenador")]
        public async Task<IActionResult> DeletarArquivo(string caminhoDoArquivo, string nomeDoArquivo)
        {
            await Task.Run(() => _deletarArquivoAppService.DeletarArquivoAsync(caminhoDoArquivo));

            var caminhoDoDiretorio = caminhoDoArquivo.Replace(nomeDoArquivo, "");
            var urlEncode = _encoder.Encode(caminhoDoDiretorio);
            return Redirect("ConteudoCoordenador?DiretorioDaUnidade=" + urlEncode);
        }
    }
}