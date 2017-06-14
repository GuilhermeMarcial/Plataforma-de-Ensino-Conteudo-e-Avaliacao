using Microsoft.AspNetCore.Mvc;

namespace PlataformaDeEnsino.Presenter.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ErrosController : Controller
    {
        public ErrosController()
        {
        }

        [Route("Erro")]
        public ViewResult Erro()
        {
            return View();
        }

        [Route("Erro/{0}")]
        public ViewResult CodigoDeStatus()
        {
            var codigoDeStatusUrl = Request.Path.Value;
            ViewBag.codigoDeErro = codigoDeStatusUrl.Replace("/Erro/", "");
            return View();
        }      
    }
}