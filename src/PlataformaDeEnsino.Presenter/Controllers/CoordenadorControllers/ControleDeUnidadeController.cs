using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.Coordenadores.Controllers.CoordenadorControllers
{
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
    public class ControleDeUnidadeController : Controller
    {
        private readonly IMapper _mapper;
        private Coordenador _coordenadorUsuario;
        private readonly IModuloAppService _moduloAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IProfessorAppService _professorAppService;
        private readonly ICoordenadorAppService _coordenadorAppService;

        public ControleDeUnidadeController(ICoordenadorAppService coordenadorAppService, IMapper mapper,
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

        public async Task<ViewResult> Unidade(int idDoModulo, int idDaUnidade)
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            ViewBag.UserName = $"{_coordenadorUsuario.Pessoa.NomeDaPessoa} {_coordenadorUsuario.Pessoa.SobrenomeDaPessoa}";
            var moduloViewModel = _mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>(await _moduloAppService.ConsultarModulosDoCursoAsync(_coordenadorUsuario.IdDoCurso));
            var unidadeViewModel = _mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(await _unidadeAppService.ConsultarUnidadadesDoModuloAsync(idDoModulo));
            var conteudoAlunoViewModel = new ConteudoViewModel(moduloViewModel, unidadeViewModel);
            return View(conteudoAlunoViewModel);
        }
        
        public async Task<IActionResult> VisualizarUnidade(int idDaUnidade)
        {
            var unidadeViewModel = _mapper.Map<Unidade, UnidadeViewModel>(await _unidadeAppService.ConsultarPeloIdAsync(idDaUnidade));
            var professorViewModel = _mapper.Map<Professor, ProfessorViewModel>(await _professorAppService.ConsultarPelaUnidadeAsync(Convert.ToInt32(unidadeViewModel.IdDoProfessor)));
            var vincularProfessorViewModel = new VincularProfessorViewModel(unidadeViewModel, professorViewModel);
            return View(vincularProfessorViewModel);
        }

        public async Task<IActionResult> VincularProfessor(int idDaUnidade)
        {
            var unidadeViewModel = _mapper.Map<Unidade, UnidadeViewModel>(await _unidadeAppService.ConsultarPeloIdAsync(idDaUnidade));
            
            TempData["IdDaUnidade"] = unidadeViewModel.IdDaUnidade;
            TempData["NomeDaUnidade"] = unidadeViewModel.NomeDaUnidade;
            TempData["DiretorioDaUnidade"] = unidadeViewModel.DiretorioDaUnidade;
            TempData["IdDoModulo"] = unidadeViewModel.IdDoModulo;
            
            var professoresViewModel = _mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorViewModel>>(await _professorAppService.ConsultarTodosProfessoresAsync());
            var vincularProfessorViewModel = new VincularProfessorViewModel(unidadeViewModel, professoresViewModel);
            return View(vincularProfessorViewModel);
        }

        [HttpPost]
        public IActionResult VincularProfessor(UnidadeViewModel unidadeViewModel)
        {
            unidadeViewModel.IdDaUnidade = (int)TempData["IdDaUnidade"];
            unidadeViewModel.NomeDaUnidade = TempData["NomeDaUnidade"] as string ;
            unidadeViewModel.DiretorioDaUnidade = TempData["DiretorioDaUnidade"] as string;
            unidadeViewModel.IdDoModulo = (int)TempData["IdDoModulo"];

            var unidade = _mapper.Map<UnidadeViewModel, Unidade>(unidadeViewModel);
            _unidadeAppService.AtualizarAsync(unidade);
            return Redirect($"VisualizarUnidade?IdDaUnidade={unidadeViewModel.IdDaUnidade}");
        }
    }
}