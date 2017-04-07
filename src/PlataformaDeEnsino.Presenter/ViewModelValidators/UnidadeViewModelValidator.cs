using System;
using System.Text.RegularExpressions;
using FluentValidation;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class UnidadeViewModelValidator : AbstractValidator<UnidadeViewModel>
    {
        public UnidadeViewModelValidator()
        {
            RuleFor(n => n.NomeDaUnidade)
            .NotEmpty().WithMessage("Informe o nome da unidade")
            .Length(3, 50).WithMessage("O nome deve conter no minino 3 caracteres e no máximo 50")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(m => m.IdDoModulo)
            .NotEmpty().WithMessage("Selecione o modulo dessa unidade")
            .Must(SomenteNumeros).WithMessage("Valor invalido");
            RuleFor(p => p.IdDoProfessor)
            .NotEmpty().WithMessage("Selecione o professor dessa unidade")
            .Must(SomenteNumeros).WithMessage("Valor invalido");
        }
        public static bool SomenteNumeros(int input)
        {   
            var inputString = Convert.ToString(input);
            var padraoNumeros = "^[0-9]{1,}$";
            Match resultado = Regex.Match(inputString, padraoNumeros);
            return (resultado.Success) ? true : false;
        }
    }
}