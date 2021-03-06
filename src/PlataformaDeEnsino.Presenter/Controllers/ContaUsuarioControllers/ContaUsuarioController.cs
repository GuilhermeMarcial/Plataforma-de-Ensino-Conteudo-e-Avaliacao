using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Presenter.ViewModels.ContaUsuarioViewModels;

namespace PlataformaDeEnsino.Presenter.Controllers.ContaUsuarioControllers
{
    [AutoValidateAntiforgeryToken]
    public class ContaUsuarioController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ContaUsuarioController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("")]
        [AllowAnonymous]
        public IActionResult LoginUsuario()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("RedirecionarUsuario");
            }

            return View();
        }

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUsuario(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                var usuario = await _userManager.FindByEmailAsync(loginViewModel.emailDoUsuario);
                if (usuario != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(usuario, loginViewModel.cpfDoUsuario, false, false);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("All", "CPF incorreto");
                        return View(loginViewModel);
                    }
                    
                    return RedirectToAction("RedirecionarUsuario");
                }
                else
                {
                    ModelState.AddModelError("All", "Login Invalido");
                    return View(loginViewModel);
                }
            }
            return View(loginViewModel);
        }

        [HttpGet("RedirecionarUsuario")]
        public IActionResult RedirecionarUsuario()
        {
            if (User.IsInRole("Aluno"))
            {
                return Redirect("Aluno/Conteudo");
            }
            if (User.IsInRole("Professor"))
            {
                return Redirect("Professor/Conteudo");
            }
            if (User.IsInRole("Coordenador"))
            {
                return Redirect("Coordenador/Conteudo");
            }
            else
            {
                return Redirect("Login");
            }
        }

        [HttpGet("LogOff")]
        [Authorize]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LoginUsuario");
        }
    }
}