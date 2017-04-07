using System.IO;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class UploadDoArquivoViewModelValidator : AbstractValidator<UploadDoArquivoViewModel>
    {
        public UploadDoArquivoViewModelValidator()
        {
            RuleFor(f => f.arquivo).NotEmpty().WithMessage("Selecio um arquivo para upload")
            .Must(SomenteArquivosPDF).WithMessage("Somente é aceito arquivos PDF");
        }
        private static bool SomenteArquivosPDF(IFormFile arquivo)
        {
            var extensaoDoArquivo = Path.GetExtension(arquivo.FileName);

            return (extensaoDoArquivo.Equals("pdf") && (arquivo.ContentType.Equals("application/pdf"))) ? true : false;
        }
    }
}