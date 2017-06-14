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
    public class ControleDeAlunoController : Controller
    {
        private readonly IMapper _mapper;
        private Coordenador _coordenadorUsuario;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IAlunoAppService _alunoAppService;
        private readonly ICursoAppService _cursoAppService;
        private readonly UserManager<AppUser> _userManager;

        public ControleDeAlunoController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAlunoAppService alunoAppService, ICursoAppService cursoAppService, ICoordenadorAppService coordenadorAppService)
        {
            _mapper = mapper;
            _alunoAppService = alunoAppService;
            _cursoAppService = cursoAppService;
            _userManager = userManager;
            _coordenadorAppService = coordenadorAppService;
        }

        private async Task<Coordenador> CoodernadorUsuario()
        {
            return await _coordenadorAppService.ConsultarPeloCpfAsync(User.Identity.Name);
        }

        public async Task<IActionResult> Alunos()
        {
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;

            ViewBag.UserName = $"{_coordenadorUsuario.NomeDaPessoa} {_coordenadorUsuario.SobrenomeDaPessoa}";
            var alunosViewModel = _mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(await _alunoAppService.SelecionarAlunosPeloCursoAsync(_coordenadorUsuario.IdDoCurso));
            return View(alunosViewModel);
        }

        public ViewResult NovoAluno()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoAluno(AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                alunoViewModel.Role = "Aluno";
                var aluno = _mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);
                _alunoAppService.InserirAsync(aluno);
                var user = new AppUser { UserName = alunoViewModel.CpfDaPessoa, Email = alunoViewModel.EmailDaPessoa };
                var resultCreate = await _userManager.CreateAsync(user, alunoViewModel.CpfDaPessoa);

                if (resultCreate.Succeeded)
                {
                    var resultRole = await _userManager.AddToRoleAsync(user, alunoViewModel.Role);
                    if (resultRole.Succeeded)
                    {
                        return Redirect("Alunos");
                    }
                }
            }
            return View(alunoViewModel);
        }

        public async Task<IActionResult> VisualizarAluno(int idDoAluno, int idDoCurso)
        {
            ViewBag.Curso = _mapper.Map<Curso, CursoViewModel>(await _cursoAppService.ConsultarPeloIdAsync(idDoCurso));

            var alunoViewModel = _mapper.Map<Aluno, AlunoViewModel>(await _alunoAppService.ConsultarPeloIdAsync(idDoAluno));
            alunoViewModel.Usuario = await _userManager.FindByNameAsync(alunoViewModel.CpfDaPessoa);

            return View(alunoViewModel);
        }

        public async Task<ViewResult> EditarAluno(int idDoAluno, string idDoUsuario)
        {
            TempData["idDoAluno"] = idDoAluno;
            TempData["idDoUsuario"] = idDoUsuario;
            TempData["Role"] = "Aluno";
            
            var alunoViewModel = _mapper.Map<Aluno, AlunoViewModel>(await _alunoAppService.ConsultarPeloIdAsync(idDoAluno));
        
            alunoViewModel.Usuario = await _userManager.FindByIdAsync(idDoUsuario);

            return View(alunoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarAluno(AlunoViewModel alunoViewModel)
        {
            var idDoUsuario = TempData["idDoUsuario"] as string;
            var idDoAluno = TempData["idDoAluno"] as int?;
            var role = TempData["Role"] as string;

            alunoViewModel.IdDoAluno = idDoAluno;
            alunoViewModel.Role = role;

            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByIdAsync(idDoUsuario);

                if (usuario != null)
                {
                    var userChangePassword = await _userManager.ChangePasswordAsync(usuario, usuario.UserName, alunoViewModel.CpfDaPessoa);
                    if (userChangePassword.Succeeded)
                    {
                        usuario.UserName = alunoViewModel.CpfDaPessoa;
                        usuario.Email = alunoViewModel.EmailDaPessoa;
                        var resultadoDaAtualizacaoDoUsuario = await _userManager.UpdateAsync(usuario);
                        if (resultadoDaAtualizacaoDoUsuario.Succeeded)
                        {   
                            var aluno = _mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);
                            _alunoAppService.AtualizarAsync(aluno);
                            return Redirect(
                                $"VisualizarAluno?IdDoAluno={alunoViewModel.IdDoAluno}&IdDoCurso={alunoViewModel.IdDoCurso}");
                        }
                    }
                }
            }
            return View(alunoViewModel);
        }
        [HttpGet("DeletarAluno")]
        public async Task<IActionResult> DeletarAluno(int idDoAluno)
        {
            var alunoAsync = _alunoAppService.ConsultarPeloIdAsync(idDoAluno);
            var aluno = await alunoAsync;
            var usuario = await _userManager.FindByNameAsync(aluno.CpfDaPessoa);
            var deletandoUsuario = await _userManager.DeleteAsync(usuario);

            if (deletandoUsuario.Succeeded)
            {
                _alunoAppService.DeletarAsync(aluno.IdDoAluno);
            }

            return Redirect("Alunos");
        }
    }
}