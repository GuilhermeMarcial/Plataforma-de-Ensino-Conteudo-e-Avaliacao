using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.Coordenadores.Controllers.CoordenadorControllers
{
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
    public class ControleDeProfessorController : Controller
    {
        private readonly IMapper _mapper;
        private Coordenador _coordenadorUsuario;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IProfessorAppService _professorAppService;
        private readonly UserManager<AppUser> _userManager;

        public ControleDeProfessorController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        IProfessorAppService professorAppService, IUnidadeAppService unidadeAppService, ICoordenadorAppService coordenadorAppService)
        {
            _mapper = mapper;
            _professorAppService = professorAppService;
            _userManager = userManager;
            _coordenadorAppService = coordenadorAppService;
        }

        private async Task<Coordenador> CoodernadorUsuario()
        {
            return await _coordenadorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        public async Task<IActionResult> Professores()
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            ViewBag.UserName = $"{_coordenadorUsuario.NomeDaPessoa} {_coordenadorUsuario.SobrenomeDaPessoa}";
            var professorViewModel = _mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorViewModel>>(await _professorAppService.ConsultarTodosAsync());
            return View(professorViewModel);
        }

        public ViewResult NovoProfessor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoProfessor(ProfessorViewModel professorViewModel)
        {
            professorViewModel.Role = "Professor";
            if (ModelState.IsValid)
            {
                var professor = _mapper.Map<ProfessorViewModel, Professor>(professorViewModel);
                _professorAppService.InserirAsync(professor);
                var user = new AppUser { UserName = professorViewModel.CpfDaPessoa, Email = professorViewModel.EmailDaPessoa };
                var resultCreate = await _userManager.CreateAsync(user, professorViewModel.CpfDaPessoa);
                if (resultCreate.Succeeded)
                {
                    var resultRole = await _userManager.AddToRoleAsync(user, professorViewModel.Role);
                    if (resultRole.Succeeded)
                    {
                        return Redirect("Professores");
                    }
                }
            }
            return View(professorViewModel);
        }

        public async Task<IActionResult> VisualizarProfessor(int idDoProfessor)
        {
            var professorViewModel = _mapper.Map<Professor, ProfessorViewModel>(await _professorAppService.ConsultarPeloIdAsync(idDoProfessor));
            professorViewModel.Usuario = await _userManager.FindByNameAsync(professorViewModel.CpfDaPessoa);
            return View(professorViewModel);
        }

        public async Task<ViewResult> EditarProfessor(int idDoProfessor, string idDoUsuario)
        {
            TempData["idDoProfessor"] = idDoProfessor;
            TempData["idDoUsuario"] = idDoUsuario;
            TempData["Role"] = "Professor";
            
            var professorViewModel = _mapper.Map<Professor, ProfessorViewModel>(await _professorAppService.ConsultarPeloIdAsync(idDoProfessor));
            
            professorViewModel.Usuario = await _userManager.FindByIdAsync(idDoUsuario);
            return View(professorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarProfessor(ProfessorViewModel professorViewModel)
        {
            var idDoUsuario = TempData["idDoUsuario"] as string;
            var idDoProfessor = TempData["idDoProfessor"] as int?;
            var role = TempData["Role"] as string;

            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByIdAsync(idDoUsuario);
                if (usuario != null)
                {
                    var userChangePassword = await _userManager.ChangePasswordAsync(usuario, usuario.UserName, professorViewModel.CpfDaPessoa);
                    if (userChangePassword.Succeeded)
                    {
                        usuario.UserName = professorViewModel.CpfDaPessoa;
                        usuario.Email = professorViewModel.EmailDaPessoa;
                        var resultadoDaAtualizacaoDoUsuario = await _userManager.UpdateAsync(usuario);
                        if (resultadoDaAtualizacaoDoUsuario.Succeeded)
                        {
                            professorViewModel.IdDoProfessor = idDoProfessor;
                            professorViewModel.Role = role;
                            
                            var professor = _mapper.Map<ProfessorViewModel, Professor>(professorViewModel);
                            _professorAppService.AtualizarAsync(professor);
                            return Redirect($"VisualizarProfessor?IdDoProfessor={professorViewModel.IdDoProfessor}");
                        }
                    }
                }
            }
            return View(professorViewModel);
        }

        [HttpGet("DeletarProfessor")]
        public async Task<IActionResult> DeletarProfessor(int idDoProfessor)
        {
            var professorAsync = _professorAppService.ConsultarPeloIdAsync(idDoProfessor);
            var professor = await professorAsync;
            var usuario = await _userManager.FindByNameAsync(professor.CpfDaPessoa);
            var deletandoUsuario = await _userManager.DeleteAsync(usuario);

            if (deletandoUsuario.Succeeded)
            {
                _professorAppService.DeletarAsync(professor.IdDoProfessor);
            }

            return Redirect("Professores");
        }
    }
}