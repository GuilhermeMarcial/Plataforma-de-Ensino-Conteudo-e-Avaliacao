using FluentValidation;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class ProfessorViewModelValidator : AbstractValidator<ProfessorViewModel>
    {
        public ProfessorViewModelValidator()
        {
            RuleFor(n => n.NomeDoProfessor)
            .NotEmpty().WithMessage("Informe o nome do professor")
            .Length(3, 50).WithMessage("O nome deve conter no minino 3 caracteres e no máximo 50")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(s => s.SobrenomeDoProfessor)
            .NotEmpty().WithMessage("Informe o sobrenome do professor")
            .Length(3, 100).WithMessage("O sobrenome deve conter no minimo 3 caracteres e no maximo 100")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(c => c.CpfDoProfessor)
            .NotEmpty().WithMessage("Informe o CPF do professor")
            .Length(14).WithMessage("O cpf deve conter no minimo 11 digitos, sem os caracteres especiais")
            .Matches("^[0-9]{1,}$").WithMessage("O campo aceita somente caracteres numericos");
        }
    }
}