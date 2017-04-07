using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class UploadDoArquivoViewModel
    {
        public IFormFile arquivo { get; set; }
    }
}