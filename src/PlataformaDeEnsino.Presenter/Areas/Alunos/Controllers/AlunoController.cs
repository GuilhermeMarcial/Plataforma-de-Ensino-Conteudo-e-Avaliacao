using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces.ArquivosInterfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Areas.Alunos.Controllers
{
    [Area("Alunos")]
    [Route("Aluno")]
    [Authorize(Roles = "Aluno")]
    [AutoValidateAntiforgeryToken]
    public class AlunoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IModuloAppService _moduloAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IRecuperarArquivosAppService _arquivoAppService;
        private readonly IAlunoAppService _alunoAppService;
        private IEnumerable<FileInfo> _arquivos;
        private  Aluno _alunoUsuario;

        public AlunoController(IMapper mapper, IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService, IRecuperarArquivosAppService arquivoAppService, IAlunoAppService alunoAppService)
        {
            _mapper = mapper;
            _moduloAppService = moduloAppService;
            _unidadeAppService = unidadeAppService;
            _arquivoAppService = arquivoAppService;
            _alunoAppService = alunoAppService;
        }

        private async Task<Aluno> AlunoUsuario()
        {
           return await  _alunoAppService.ConsultarAlunoPeloCpfAsync(User.Identity.Name);
        }

        [HttpGet("Conteudo")]
        public async Task<IActionResult> ConteudoAluno([FromQuery] int idDoModulo, string diretorioDaUnidade)
        {
            var alunoUsuario = AlunoUsuario();
            _alunoUsuario = await alunoUsuario;
            
            ViewBag.UserName = $"{_alunoUsuario.NomeDaPessoa} {_alunoUsuario.SobrenomeDaPessoa}";
            
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_alunoUsuario.IdDoCurso, _alunoUsuario.NivelDoAluno));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            
            _arquivos = diretorioDaUnidade != null ? await _arquivoAppService.RecuperarArquivosAsync(diretorioDaUnidade) : null;
            
            var conteudoAlunoViewModel = new ConteudoViewModel(moduloViewModel, unidadeViewModel, _arquivos);
            return View(conteudoAlunoViewModel);
        }
    }
}