using FluentValidation;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class ConteudoAlunoViewModelValidator : AbstractValidator<ConteudoViewModel>
    {
        public ConteudoAlunoViewModelValidator()
        {
            RuleFor(a => a.ModuloViewModel)
                .NotEmpty()
                .WithMessage("Seleciona um modulo");
            RuleFor(a => a.UnidadeViewModel)
                .NotEmpty()
                .WithMessage("Seleciona uma unidade");
            RuleFor(a => a.Arquivo)
                .NotEmpty()
                .WithMessage("Selecione um arquivo");
        }
    }
}