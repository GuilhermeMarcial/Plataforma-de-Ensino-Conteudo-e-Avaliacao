using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
    public class UnidadeCoordenadorController : Controller
    {
        private readonly IMapper _mapper;
        private Coordenador _coordenadorUsuario;
        private readonly IModuloAppService _moduloAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IProfessorAppService _professorAppService;
        private readonly ICoordenadorAppService _coordenadorAppService;

        public UnidadeCoordenadorController(ICoordenadorAppService coordenadorAppService, IMapper mapper,
        IModuloAppService moduloAppService, IUnidadeAppService unidadeAppService, IProfessorAppService professorAppService)
        {
            _mapper = mapper;
            _moduloAppService = moduloAppService;
            _unidadeAppService = unidadeAppService;
            _coordenadorAppService = coordenadorAppService;
            _professorAppService = professorAppService;
        }

        private async Task<Coordenador> CoodernadorUsuario()
        {
            return await _coordenadorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        [HttpGet("Unidade")]
        public async Task<ViewResult> Unidade(int idDoModulo, int idDaUnidade)
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            ViewBag.UserName = _coordenadorUsuario.NomeDoCoordenador + " " + _coordenadorUsuario.SobrenomeDoCoordenador;
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            var ConteudoAlunoViewModel = new ConteudoAlunoViewModel(moduloViewModel, unidadeViewModel);
            return View(ConteudoAlunoViewModel);
        }

        [HttpGet("VisualizarUnidade")]
        public async Task<IActionResult> VisualizarUnidade(int idDaUnidade)
        {
            var unidadeViewModel = _mapper.Map<Unidade, UnidadeViewModel>(await _unidadeAppService.ConsultarPeloIdAsync(idDaUnidade));
            var professorViewModel = _mapper.Map<Professor, ProfessorViewModel>(await _professorAppService.ConsultarPeloIdAsync(Convert.ToInt32(unidadeViewModel.IdDoProfessor)));
            var VincularProfessorViewModel = new VincularProfessorViewModel(unidadeViewModel, professorViewModel);
            return View(VincularProfessorViewModel);
        }

        [HttpGet("VincularProfessor")]
        public async Task<IActionResult> VincularProfessor(int idDaUnidade)
        {
            var unidadeViewModel = _mapper.Map<Unidade, UnidadeViewModel>(await _unidadeAppService.ConsultarPeloIdAsync(idDaUnidade));
            var professoresViewModel = _mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorViewModel>>(await _professorAppService.ConsultarTodosAsync());
            var VincularProfessorViewModel = new VincularProfessorViewModel(unidadeViewModel, professoresViewModel);
            return View(VincularProfessorViewModel);
        }

        [HttpPost("VincularProfessor")]
        public IActionResult VincularProfessor(UnidadeViewModel unidadeViewModel)
        {
            var unidade = _mapper.Map<UnidadeViewModel, Unidade>(unidadeViewModel);
            _unidadeAppService.AtualizarAsync(unidade);
            return Redirect("VisualizarUnidade?IdDaUnidade=" + unidadeViewModel.IdDaUnidade);
        }
    }
}