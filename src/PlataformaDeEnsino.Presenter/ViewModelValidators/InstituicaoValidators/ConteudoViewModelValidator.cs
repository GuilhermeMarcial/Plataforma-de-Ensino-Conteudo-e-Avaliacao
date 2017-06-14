using FluentValidation;
using PlataformaDeEnsino.Presenter.ViewModels;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators.InstituicaoValidators
{
    public class ConteudoViewModelValidator : AbstractValidator<ConteudoViewModel>
    {
        public ConteudoViewModelValidator()
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