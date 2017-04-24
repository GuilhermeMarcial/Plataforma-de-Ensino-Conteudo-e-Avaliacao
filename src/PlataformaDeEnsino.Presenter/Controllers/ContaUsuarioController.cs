using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    public class ContaUsuarioController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ContaUsuarioController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("")]
        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult LoginUsuario()
        {
            if(_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("RedirecionarUsuario");
            }
            
            return View();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUsuario(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                var usuario = await _userManager.FindByEmailAsync(model.emailDoUsuario);
                var result = await _signInManager.PasswordSignInAsync(usuario, model.cpfDoUsuario, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("RedirecionarUsuario");
                }
                else
                {
                    ModelState.AddModelError("All", "Login Invalido");
                    return View(model);
                }
            }
            return View(model);
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