using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Presenter.Areas.Professores.ViewModels;

namespace PlataformaDeEnsino.Presenter.Areas.Coordenadores.Controllers
{
    [Area("Coordenadores")]
    [Route("Coordenador")]
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
    public class ProfessorCoordenadorController : Controller
    {
        private readonly IMapper _mapper;
        private Coordenador _coordenadorUsuario;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IProfessorAppService _professorAppService;
        private readonly UserManager<AppUser> _userManager;

        public ProfessorCoordenadorController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
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

        [HttpGet("ProfessorCoordenador")]
        public async Task<IActionResult> ProfessorCoordenador()
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            ViewBag.UserName = $"{_coordenadorUsuario.NomeDaPessoa} {_coordenadorUsuario.SobrenomeDaPessoa}";
            var professorViewModel = _mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorViewModel>>(await _professorAppService.ConsultarTodosAsync());
            return View(professorViewModel);
        }

        [HttpGet("NovoProfessor")]
        public ViewResult NovoProfessor()
        {
            return View();
        }

        [HttpPost("NovoProfessor")]
        public async Task<IActionResult> NovoProfessor(ProfessorViewModel professorViewModel)
        {

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
                        return Redirect("ProfessorCoordenador");
                    }
                }
            }
            return View(professorViewModel);
        }

        [HttpGet("VisualizarProfessor")]
        public async Task<IActionResult> VisualizarProfessor(int idDoProfessor)
        {
             var professorViewModel = _mapper.Map<Professor, ProfessorViewModel>(await _professorAppService.ConsultarPeloIdAsync(idDoProfessor));
             professorViewModel.Usuario = await _userManager.FindByNameAsync(professorViewModel.CpfDaPessoa);
             return View(professorViewModel);
        }

        [HttpGet("EditarProfessor")]
        public async Task<ViewResult> EditarProfessor(int idDoProfessor, string idDoUsuario)
        {
              var professorViewModel = _mapper.Map<Professor, ProfessorViewModel>(await _professorAppService.ConsultarPeloIdAsync(idDoProfessor));
              professorViewModel.IdDoUsuario = idDoUsuario;
              professorViewModel.Usuario = await _userManager.FindByIdAsync(idDoUsuario);
              return View(professorViewModel);
        }
        
        [HttpPost("EditarProfessor")]
        public async Task<IActionResult> EditarProfessor(ProfessorViewModel professorViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByIdAsync(professorViewModel.IdDoUsuario);
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
            
            return Redirect("ProfessorCoordenador");
        }
    }

}