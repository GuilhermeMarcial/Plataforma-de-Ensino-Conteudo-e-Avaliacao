using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ProfessorCoordenadorController : Controller
    {
        private readonly IMapper _mapper;
        private Coordenador _coordenadorUsuario;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IProfessorAppService _professorAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfessorCoordenadorController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
        IProfessorAppService professorAppService, IUnidadeAppService unidadeAppService, ICoordenadorAppService coordenadorAppService)
        {
            _mapper = mapper;
            _professorAppService = professorAppService;
            _unidadeAppService = unidadeAppService;
            _userManager = userManager;
            _signInManager = signInManager;
            _coordenadorAppService = coordenadorAppService;
        }

        private async Task<Coordenador> CoodernadorUsuario()
        {
            return await _coordenadorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        [HttpGet("ProfessorCoordenador")]
        [Authorize(Roles = "Coordenador")]
        public async Task<IActionResult> ProfessorCoordenador()
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            ViewBag.UserName = _coordenadorUsuario.NomeDoCoordenador + " " + _coordenadorUsuario.SobrenomeDoCoordenador;
            var professorViewModel = _mapper.Map<Task<IEnumerable<Professor>>, IEnumerable<ProfessorViewModel>>(_professorAppService.ConsultarTodosAsync());
            return View(professorViewModel);
        }

        [HttpGet("NovoProfessor")]
        [Authorize(Roles = "Coordenador")]
        public ViewResult NovoProfessor()
        {
            return View();
        }

        [HttpPost("NovoProfessor")]
        [Authorize(Roles = "Coordenador")]
        public async Task<IActionResult> NovoProfessor(ProfessorViewModel professorViewModel)
        {

            if (ModelState.IsValid)
            {
                var professor = _mapper.Map<ProfessorViewModel, Professor>(professorViewModel);
                _professorAppService.InserirAsync(professor);
                var user = new AppUser { UserName = professorViewModel.CpfDoProfessor, Email = professorViewModel.EmailDoProfessor };
                var resultCreate = await _userManager.CreateAsync(user, professorViewModel.CpfDoProfessor);
                if (resultCreate.Succeeded)
                {
                    var resultRole = await _userManager.AddToRoleAsync(user, professorViewModel.Role);
                    if (resultRole.Succeeded)
                    {
                        return Redirect("ProfessorCoordenador");
                    }
                }
            }
            return View(professorViewModel);
        }

        [HttpGet("VisualizarProfessor")]
        [Authorize(Roles = "Coordenador")]
        public async Task<IActionResult> VisualizarProfessor(int? IdDoProfessor)
        {
            if (IdDoProfessor != null)
            {
                var idDoProfessor = Convert.ToInt32(IdDoProfessor);
                var professorViewModel = _mapper.Map<Task<Professor>, ProfessorViewModel>(_professorAppService.ConsultarPeloIdAsync(idDoProfessor));
                professorViewModel.Usuario = await _userManager.FindByNameAsync(professorViewModel.CpfDoProfessor);
                return View(professorViewModel);
            }
            return View();
        }

        [HttpGet("EditarProfessor")]
        [Authorize(Roles = "Coordenador")]
        public async Task<ViewResult> EditarProfessor(int? IdDoProfessor, string IdDoUsuario)
        {
            if (IdDoProfessor != null)
            {
                var idDoProfessor = Convert.ToInt32(IdDoProfessor);
                var professorViewModel = _mapper.Map<Task<Professor>, ProfessorViewModel>(_professorAppService.ConsultarPeloIdAsync(idDoProfessor));
                professorViewModel.IdDoUsuario = IdDoUsuario;
                professorViewModel.Usuario = await _userManager.FindByIdAsync(IdDoUsuario);
                return View(professorViewModel);
            }
            return View();
        }
        [HttpPost("EditarProfessor")]
        [Authorize(Roles = "Coordenador")]
        public async Task<IActionResult> EditarProfessor(ProfessorViewModel professorViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByIdAsync(professorViewModel.IdDoUsuario);
                if (usuario != null)
                {
                    var userChangePassword = await _userManager.ChangePasswordAsync(usuario, usuario.UserName, professorViewModel.CpfDoProfessor);
                    if (userChangePassword.Succeeded)
                    {
                        usuario.UserName = professorViewModel.CpfDoProfessor;
                        usuario.Email = professorViewModel.EmailDoProfessor;
                        var resultadoDaAtualizacaoDoUsuario = await _userManager.UpdateAsync(usuario);
                        if (resultadoDaAtualizacaoDoUsuario.Succeeded)
                        {
                            var professor = _mapper.Map<ProfessorViewModel, Professor>(professorViewModel);
                            _professorAppService.AtualizarAsync(professor);
                            return Redirect("VisualizarProfessor?IdDoProfessor=" + professorViewModel.IdDoProfessor);
                        }
                    }
                }
            }
            return View(professorViewModel);
        }

        [HttpGet("DeletarProfessor")]
        [Authorize(Roles = "Coordenador")]
        public async Task<IActionResult> DeletarProfessor(int IdDoProfessor)
        {
            var professorAsync = _professorAppService.ConsultarPeloIdAsync(IdDoProfessor);
            var professor = await professorAsync;
            var usuario = await _userManager.FindByNameAsync(professor.CpfDoProfessor);
            var deletandoUsuario = await _userManager.DeleteAsync(usuario);
            if (deletandoUsuario.Succeeded)
            {
                _professorAppService.DeletarAsync(professor.IdDoProfessor);
            }
            
            return Redirect("ProfessorCoordenador");
        }
    }

}