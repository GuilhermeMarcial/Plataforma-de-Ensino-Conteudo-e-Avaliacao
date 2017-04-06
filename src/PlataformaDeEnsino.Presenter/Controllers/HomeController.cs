using Microsoft.AspNetCore.Mvc;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}