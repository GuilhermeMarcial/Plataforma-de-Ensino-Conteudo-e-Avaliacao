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
        private readonly IPessoaAppService _pessoaAppService;
        private Coordenador _coordenadorUsuario;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IProfessorAppService _professorAppService;
        private readonly UserManager<AppUser> _userManager;

        public ControleDeProfessorController(IMapper mapper, IPessoaAppService pessoaAppService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        IProfessorAppService professorAppService, IUnidadeAppService unidadeAppService, ICoordenadorAppService coordenadorAppService)
        {
            _mapper = mapper;
            _pessoaAppService = pessoaAppService;
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

            ViewBag.UserName = $"{_coordenadorUsuario.Pessoa.NomeDaPessoa} {_coordenadorUsuario.Pessoa.SobrenomeDaPessoa}";
            var professorViewModel = _mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorViewModel>>(await _professorAppService.ConsultarTodosProfessoresAsync());
            return View(professorViewModel);
        }

        public ViewResult NovoProfessor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoProfessor(ProfessorViewModel professorViewModel)
        {
            if (ModelState.IsValid)
            {
                professorViewModel.IdDaPessoa = professorViewModel.Pessoa.IdDaPessoa;
                professorViewModel.Role = "Professor";

                var professor = _mapper.Map<ProfessorViewModel, Professor>(professorViewModel);
                _professorAppService.InserirAsync(professor);

                var user = new AppUser { UserName = professorViewModel.Pessoa.CpfDaPessoa, Email = professorViewModel.Pessoa.EmailDaPessoa };
                var resultCreate = await _userManager.CreateAsync(user, professorViewModel.Pessoa.CpfDaPessoa);
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
            var professorViewModel = _mapper.Map<Professor, ProfessorViewModel>(await _professorAppService.ConsultarProfessorPeloId(idDoProfessor));
            professorViewModel.Usuario = await _userManager.FindByNameAsync(professorViewModel.Pessoa.CpfDaPessoa);
            return View(professorViewModel);
        }

        public async Task<ViewResult> EditarProfessor(int idDoProfessor, string idDoUsuario)
        {
            TempData["idDoProfessor"] = idDoProfessor;
            TempData["idDoUsuario"] = idDoUsuario;
            TempData["Role"] = "Professor";
            
            var editarProfessorViewModel = _mapper.Map<Professor, EditarProfessorViewModel>(await _professorAppService.ConsultarProfessorPeloId(idDoProfessor));
            TempData["IdDaPessoa"] = editarProfessorViewModel.Pessoa.IdDaPessoa;
            TempData["CpfDaPessoa"] = editarProfessorViewModel.Pessoa.CpfDaPessoa;
            TempData["EmailDaPessoa"] = editarProfessorViewModel.Pessoa.EmailDaPessoa;
            
            editarProfessorViewModel.Usuario = await _userManager.FindByIdAsync(idDoUsuario);
            return View(editarProfessorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarProfessor(EditarProfessorViewModel editarProfessorViewModel)
        {
            var idDoUsuario = TempData["idDoUsuario"] as string;
            var idDoProfessor = (int)TempData["idDoProfessor"];
            var role = TempData["Role"] as string;
            editarProfessorViewModel.IdDaPessoa = (int)TempData["IdDaPessoa"];
            var cpfDaPessoa = TempData["CpfDaPessoa"] as string;
            var emailDaPessoa = TempData["EmailDaPessoa"] as string;
            
            TempData.Keep();

            if (ModelState.IsValid)
            {
                if(await _pessoaAppService.PessoaExisteCpfAsync(cpfDaPessoa, editarProfessorViewModel.Pessoa.CpfDaPessoa))
                {
                    ModelState.AddModelError("Pessoa.CpfDaPessoa", "Cpf já esta em uso");
                    return View(editarProfessorViewModel);
                }

                if(await _pessoaAppService.PessoaExisteEmailAsync(emailDaPessoa, editarProfessorViewModel.Pessoa.EmailDaPessoa))
                {
                    
                    ModelState.AddModelError("Pessoa.EmailDaPessoa", "E-Mail já esta em uso");
                    return View(editarProfessorViewModel);
                
                }

                editarProfessorViewModel.Pessoa.IdDaPessoa = editarProfessorViewModel.IdDaPessoa;
                var pessoa = _mapper.Map<PessoaViewModel, Pessoa>(editarProfessorViewModel.Pessoa);
                _pessoaAppService.AtualizarAsync(pessoa);

                var usuario = await _userManager.FindByIdAsync(idDoUsuario);
                if (usuario != null)
                {
                    var userChangePassword = await _userManager.ChangePasswordAsync(usuario, usuario.UserName, editarProfessorViewModel.Pessoa.CpfDaPessoa);
                    if (userChangePassword.Succeeded)
                    {
                        usuario.UserName = editarProfessorViewModel.Pessoa.CpfDaPessoa;
                        usuario.Email = editarProfessorViewModel.Pessoa.EmailDaPessoa;
                        var resultadoDaAtualizacaoDoUsuario = await _userManager.UpdateAsync(usuario);
                        if (resultadoDaAtualizacaoDoUsuario.Succeeded)
                        {
                            editarProfessorViewModel.IdDoProfessor = idDoProfessor;
                            editarProfessorViewModel.Role = role;
                            
                            var professor = _mapper.Map<EditarProfessorViewModel, Professor>(editarProfessorViewModel);
                            _professorAppService.AtualizarAsync(professor);
                            return Redirect($"VisualizarProfessor?IdDoProfessor={editarProfessorViewModel.IdDoProfessor}");
                        }
                    }
                }
            }
            return View(editarProfessorViewModel);
        }

        public async Task<IActionResult> DeletarProfessor(int idDoProfessor)
        {
            var professorAsync = _professorAppService.ConsultarProfessorPeloId(idDoProfessor);
            var professor = await professorAsync;
            var usuario = await _userManager.FindByNameAsync(professor.Pessoa.CpfDaPessoa);
            var deletandoUsuario = await _userManager.DeleteAsync(usuario);

            if (deletandoUsuario.Succeeded)
            {
                _pessoaAppService.DeletarAsync(professor.IdDaPessoa);
            }

            return Redirect("Professores");
        }
    }
}