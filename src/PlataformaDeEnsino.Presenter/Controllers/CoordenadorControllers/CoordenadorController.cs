using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Presenter.Coordenadores.ViewModels.InstituicaoViewModels;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.Controllers.CoordenadorControllers
{
    [Authorize(Roles = "Coordenador")]
    [AutoValidateAntiforgeryToken]
    public class CoordenadorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPessoaAppService _pessoaAppService;
        private readonly ICoordenadorAppService _coordenadorAppService;
        private readonly UserManager<AppUser> _userManager;
    
        public CoordenadorController(IMapper mapper, IPessoaAppService pessoaAppService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAlunoAppService alunoAppService, ICursoAppService cursoAppService, ICoordenadorAppService coordenadorAppService)
        {
            _mapper = mapper;
            _pessoaAppService = pessoaAppService;
            _userManager = userManager;
            _coordenadorAppService = coordenadorAppService;
        }

        public async Task<ViewResult> TrocaDeSenha()
        {
            var coordenadorViewModel = _mapper.Map<Coordenador, CoordenadorViewModel>(await _coordenadorAppService.ConsultarPeloCpfAsync(User.Identity.Name));
            TempData["IdDaPessoa"] = coordenadorViewModel.Pessoa.IdDaPessoa;
            TempData["CpfDaPessoa"] = coordenadorViewModel.Pessoa.CpfDaPessoa;
            TempData["NomeDaPessoa"] = coordenadorViewModel.Pessoa.NomeDaPessoa;
            TempData["SobrenomeDaPessoa"] = coordenadorViewModel.Pessoa.SobrenomeDaPessoa;
            TempData["EmailDaPessoa"] = coordenadorViewModel.Pessoa.EmailDaPessoa;
            return View(coordenadorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TrocaDeSenha(CoordenadorViewModel coordenadorViewModel)
        {
            coordenadorViewModel.IdDaPessoa = (int)TempData["IdDaPessoa"];
            coordenadorViewModel.Pessoa.EmailDaPessoa = TempData["EmailDaPessoa"] as string;
            coordenadorViewModel.Pessoa.NomeDaPessoa = TempData["NomeDaPessoa"] as string;
            coordenadorViewModel.Pessoa.SobrenomeDaPessoa = TempData["SobrenomeDaPessoa"] as string;
            var cpfDaPessoa = TempData["CpfDaPessoa"] as string;
            TempData.Keep();
            
            if(ModelState.IsValid)
            {
                coordenadorViewModel.Pessoa.IdDaPessoa = coordenadorViewModel.IdDaPessoa;
                var pessoa = _mapper.Map<PessoaViewModel, Pessoa>(coordenadorViewModel.Pessoa);
                _pessoaAppService.AtualizarAsync(pessoa);

                var usuario = await _userManager.FindByNameAsync(cpfDaPessoa);

                if (usuario != null)
                {
                    var userChangePassword = await _userManager.ChangePasswordAsync(usuario, usuario.UserName, coordenadorViewModel.Pessoa.CpfDaPessoa);
                    if (userChangePassword.Succeeded)
                    {
                        usuario.UserName = coordenadorViewModel.Pessoa.CpfDaPessoa;
                        usuario.Email = coordenadorViewModel.Pessoa.EmailDaPessoa;
                        var resultadoDaAtualizacaoDoUsuario = await _userManager.UpdateAsync(usuario);
                        if (resultadoDaAtualizacaoDoUsuario.Succeeded)
                        {
                            return RedirectToAction("LogOff", "ContaUsuario");
                        }
                    }

                }
            }
            return View(coordenadorViewModel);
        }
    }
}