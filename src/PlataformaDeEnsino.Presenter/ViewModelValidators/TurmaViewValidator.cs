using System;
using FluentValidation;
using System.Text.RegularExpressions;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class TurmaViewModelValidator : AbstractValidator<TurmaViewModel>
    {
        public TurmaViewModelValidator()
        {
            RuleFor(c => c.CodigoDaTurma)
            .NotEmpty().WithMessage("Informe o codigo da turma")
            .Length(3, 50).WithMessage("O codigo deve conter no minino 3 caracteres e no máximo 50")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(c => c.IdDoCurso)
            .NotEmpty().WithMessage("Selecione o curso da turma")
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