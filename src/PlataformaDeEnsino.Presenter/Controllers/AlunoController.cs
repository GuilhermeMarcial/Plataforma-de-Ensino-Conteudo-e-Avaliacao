using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PlataformaDeEnsino.Identity.Models;
using System.Threading.Tasks;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    [Route("Aluno")]
    [AutoValidateAntiforgeryToken]
    public class AlunoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IModuloAppService _moduloAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IRecuperarArquivosAppService _arquivoAppService;
        private readonly IAlunoAppService _alunoAppService;
        private IEnumerable<FileInfo> arquivos;
        private  Aluno _alunoUsuario;

        public AlunoController(IMapper mapper, IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService, IRecuperarArquivosAppService arquivoAppService, IAlunoAppService alunoAppService)
        {
            _mapper = mapper;
            _moduloAppService = moduloAppService;
            _unidadeAppService = unidadeAppService;
            _arquivoAppService = arquivoAppService;
            _alunoAppService = alunoAppService;
        }

        private Aluno AlunoUsuario()
        {
           return  _alunoAppService.ConsultarAlunoPeloCpf(User.Identity.Name);
        }

        [HttpGet("Conteudo")]
        [Authorize(Roles = "Aluno")]
        public IActionResult ConteudoAluno([FromQuery] int idDoModulo, string DiretorioDaUnidade)
        {
            _alunoUsuario = AlunoUsuario();
            ViewBag.UserName = _alunoUsuario.NomeDoAluno + " " + _alunoUsuario.SobrenomeDoAluno;
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(_moduloAppService.ConsultarModulosDoCurso(_alunoUsuario.IdDoCurso, _alunoUsuario.NivelDoAluno));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(_unidadeAppService.ConsultarUnidadadesDoModulo(idDoModulo));
            arquivos = DiretorioDaUnidade != null ? _arquivoAppService.RecuperarArquivos(DiretorioDaUnidade) : null;
            var ConteudoAlunoViewModel = new ConteudoAlunoViewModel(moduloViewModel, unidadeViewModel, arquivos);
            return View(ConteudoAlunoViewModel);
        }

        [HttpGet("Download")]
        [Authorize(Roles = "Aluno")]
        public FileResult DownloadFile(string caminhoDoArquivo)
        {
            var file = new FileInfo(caminhoDoArquivo);
            byte[] fileBytes =  System.IO.File.ReadAllBytes(file.FullName);
            return File(fileBytes, "application/pdf", file.Name);
        }
    }
}