using FluentValidation;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(t => t.emailDoUsuario)
                .NotEmpty().WithMessage("Informe o Email")
                .Length(5, 50).WithMessage("Verifique o tamanho do email")
                .Matches("[A-Za-z0-9\\._-]+@[A-Za-z0-9]+(\\.[A-Za-z]+)*").WithMessage("Informe um email valido");
            RuleFor(t => t.cpfDoUsuario)
                .NotEmpty().WithMessage("Informe o CPF")
                .Length(10, 12).WithMessage("Cpf deve conter no minimo 10 digitos")
                .Matches("^[0-9]{1,}$").WithMessage("O campo só aceita numeros");
        }
    }
}