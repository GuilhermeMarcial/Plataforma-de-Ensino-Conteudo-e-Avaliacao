using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.Coordenadores.Controllers.CoordenadorControllers
{
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
    public class CoordenadorController : Controller
    {
        private IEnumerable<FileInfo> _arquivos;
        private readonly UrlEncoder _encoder;
        private readonly IMapper _mapper;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IModuloAppService _moduloAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IRecuperarArquivosAppService _recuperarArquivoAppService;
        private readonly IEnviarArquivosAppService _enviarArquivoAppService;
        private Coordenador _coordenadorUsuario;
        
        public CoordenadorController(IMapper mapper, IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService,
        IRecuperarArquivosAppService recuperarArquivoAppService, IDelecaoDeArquivosAppService deletarArquivoAppService,
        IEnviarArquivosAppService enviarArquivoAppService, ICoordenadorAppService coordenadorAppService, 
        ILerArquivoEmBytesAppService lerArquivoEmBytesAppService, ILerArquivoAppService lerArquivoAppService)
        {
            _mapper = mapper;
            _moduloAppService = moduloAppService;
            _unidadeAppService = unidadeAppService;
            _recuperarArquivoAppService = recuperarArquivoAppService;
            _enviarArquivoAppService = enviarArquivoAppService;
            _coordenadorAppService = coordenadorAppService;
            _encoder = UrlEncoder.Create();
        }

        private async Task<Coordenador> CoodernadorUsuario()
        {
            return await _coordenadorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        public async Task<IActionResult> Conteudo(int idDoModulo, string diretorioDaUnidade)
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            ViewBag.UserName = $"{_coordenadorUsuario.NomeDaPessoa} {_coordenadorUsuario.SobrenomeDaPessoa}";
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            _arquivos = diretorioDaUnidade != null ? await _recuperarArquivoAppService.RecuperarArquivosAsync(diretorioDaUnidade) : null;
            var conteudoAlunoViewModel = new ConteudoViewModel(moduloViewModel, unidadeViewModel, _arquivos);
            return View(conteudoAlunoViewModel);
        }

        public async Task<ViewResult> SelecionarConteudo(int idDoModulo)
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            var conteudoViewModel = new ConteudoViewModel(moduloViewModel, unidadeViewModel);
            return View(conteudoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelecionarConteudo(string diretorioDaUnidade, IFormFile arquivo)
        {
            if ((diretorioDaUnidade == null) || (arquivo == null)) 
            {
                TempData["erroAoEnviarArquivo"] = "Antes de enviar um arquivo, selecione a unidade e arquivo";
                return Redirect("SelecionarConteudo");
            }

            var urlEncode = _encoder.Encode(diretorioDaUnidade);
            await _enviarArquivoAppService.EnviarArquivos(diretorioDaUnidade, arquivo);
            return Redirect($"Conteudo?DiretorioDaUnidade={urlEncode}");
        }
    }
}