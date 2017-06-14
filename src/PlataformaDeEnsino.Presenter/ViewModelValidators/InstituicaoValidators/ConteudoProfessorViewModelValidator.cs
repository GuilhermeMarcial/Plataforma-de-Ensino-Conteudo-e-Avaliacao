using FluentValidation;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators.InstituicaoValidators
{
    public class ConteudoProfessorViewModelValidator : AbstractValidator<ConteudoProfessorViewModel>
    {
        public ConteudoProfessorViewModelValidator()
        {
            RuleFor(p => p.UnidadeViewModel).NotEmpty().WithMessage("Seleciona uma unidade");
            RuleFor(p => p.Arquivo).NotEmpty().WithMessage("Selecione um arquivo");
        }
    }
}