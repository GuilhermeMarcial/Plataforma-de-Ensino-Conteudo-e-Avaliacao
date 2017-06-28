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
        private readonly IPessoaAppService _pessoaAppService;
        private Coordenador _coordenadorUsuario;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly IAlunoAppService _alunoAppService;
        private readonly ICursoAppService _cursoAppService;
        private readonly UserManager<AppUser> _userManager;

        public ControleDeAlunoController(IMapper mapper, IPessoaAppService pessoaAppService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAlunoAppService alunoAppService, ICursoAppService cursoAppService, ICoordenadorAppService coordenadorAppService)
        {
            _mapper = mapper;
            _pessoaAppService = pessoaAppService;
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
            TempData["CursoCoordenador"] = _coordenadorUsuario.IdDoCurso;

            ViewBag.UserName = $"{_coordenadorUsuario.Pessoa.NomeDaPessoa} {_coordenadorUsuario.Pessoa.SobrenomeDaPessoa}";
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
                alunoViewModel.IdDaPessoa = alunoViewModel.Pessoa.IdDaPessoa;
                
                alunoViewModel.Role = "Aluno";
                alunoViewModel.IdDoCurso = (int)TempData["CursoCoordenador"];
                TempData.Keep();
                

                var aluno = _mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);

                _alunoAppService.InserirAsync(aluno);
                var user = new AppUser { UserName = alunoViewModel.Pessoa.CpfDaPessoa, Email = alunoViewModel.Pessoa.EmailDaPessoa };
                var resultCreate = await _userManager.CreateAsync(user, alunoViewModel.Pessoa.CpfDaPessoa);

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

            var alunoViewModel = _mapper.Map<Aluno, AlunoViewModel>(await _alunoAppService.ConsultarAlunoPeloId(idDoAluno));
            alunoViewModel.Usuario = await _userManager.FindByNameAsync(alunoViewModel.Pessoa.CpfDaPessoa);

            return View(alunoViewModel);
        }

        public async Task<ViewResult> EditarAluno(int idDoAluno, string idDoUsuario)
        {
            TempData["idDoAluno"] = idDoAluno;
            TempData["idDoUsuario"] = idDoUsuario;
            TempData["Role"] = "Aluno";
            
            var coordenadorUsuario = CoodernadorUsuario();
            _coordenadorUsuario = await coordenadorUsuario;
            TempData["CursoCoordenador"] = _coordenadorUsuario.IdDoCurso;
            
            var editarAlunoViewModel = _mapper.Map<Aluno, EditarAlunoViewModel>(await _alunoAppService.ConsultarAlunoPeloId(idDoAluno));

            editarAlunoViewModel.Usuario = await _userManager.FindByIdAsync(idDoUsuario);
            TempData["IdDaPessoa"] = editarAlunoViewModel.Pessoa.IdDaPessoa;
            TempData["CpfDaPessoa"] = editarAlunoViewModel.Pessoa.CpfDaPessoa;
            TempData["EmailDaPessoa"] = editarAlunoViewModel.Pessoa.EmailDaPessoa;

            return View(editarAlunoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarAluno(EditarAlunoViewModel editarAlunoViewModel)
        {
            var idDoUsuario = TempData["idDoUsuario"] as string;
            editarAlunoViewModel.IdDoAluno = TempData["idDoAluno"] as int?;
            editarAlunoViewModel.Role = TempData["Role"] as string;
            editarAlunoViewModel.IdDoCurso = (int)TempData["CursoCoordenador"];
            editarAlunoViewModel.IdDaPessoa = (int)TempData["IdDaPessoa"];
            var cpfDaPessoa = TempData["CpfDaPessoa"] as string;
            var emailDaPessoa = TempData["EmailDaPessoa"] as string;

            TempData.Keep();

            

            if (ModelState.IsValid)
            {     
                if(await _pessoaAppService.PessoaExisteCpfAsync(cpfDaPessoa, editarAlunoViewModel.Pessoa.CpfDaPessoa))
                {
                    ModelState.AddModelError("Pessoa.CpfDaPessoa", "Cpf já esta em uso");
                    return View(editarAlunoViewModel);
                }

                if(await _pessoaAppService.PessoaExisteEmailAsync(emailDaPessoa, editarAlunoViewModel.Pessoa.EmailDaPessoa))
                {
                    
                    ModelState.AddModelError("Pessoa.EmailDaPessoa", "E-Mail já esta em uso");
                    return View(editarAlunoViewModel);
                
                }

                editarAlunoViewModel.Pessoa.IdDaPessoa = editarAlunoViewModel.IdDaPessoa;
                var pessoa = _mapper.Map<PessoaViewModel, Pessoa>(editarAlunoViewModel.Pessoa);
                _pessoaAppService.AtualizarAsync(pessoa);
            
                var usuario = await _userManager.FindByIdAsync(idDoUsuario);

                if (usuario != null)
                {
                    var userChangePassword = await _userManager.ChangePasswordAsync(usuario, usuario.UserName, editarAlunoViewModel.Pessoa.CpfDaPessoa);
                    if (userChangePassword.Succeeded)
                    {
                        usuario.UserName = editarAlunoViewModel.Pessoa.CpfDaPessoa;
                        usuario.Email = editarAlunoViewModel.Pessoa.EmailDaPessoa;
                        var resultadoDaAtualizacaoDoUsuario = await _userManager.UpdateAsync(usuario);
                        if (resultadoDaAtualizacaoDoUsuario.Succeeded)
                        {
                            var aluno = _mapper.Map<EditarAlunoViewModel, Aluno>(editarAlunoViewModel);
                            _alunoAppService.AtualizarAsync(aluno);
                            return Redirect(
                                $"VisualizarAluno?IdDoAluno={editarAlunoViewModel.IdDoAluno}&IdDoCurso={editarAlunoViewModel.IdDoCurso}");
                        }
                    }
                }
            }
            return View(editarAlunoViewModel);
        }
        public async Task<IActionResult> DeletarAluno(int idDoAluno)
        {
            var alunoAsync = _alunoAppService.ConsultarAlunoPeloId(idDoAluno);
            var aluno = await alunoAsync;
            var usuario = await _userManager.FindByNameAsync(aluno.Pessoa.CpfDaPessoa);
            var deletandoUsuario = await _userManager.DeleteAsync(usuario);

            if (deletandoUsuario.Succeeded)
            {
                _pessoaAppService.DeletarAsync(aluno.IdDaPessoa);
            }

            return Redirect("Alunos");
        }
    }
}
