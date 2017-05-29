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
            RuleFor(p => p.IdDoProfessor)
            .NotEmpty().WithMessage("Selecione o professor dessa unidade")
            .Must(SomenteNumeros).WithMessage("Valor invalido");
        }

        private static bool SomenteNumeros(int? input)
        {   
            var inputString = Convert.ToString(input);
            const string padraoNumeros = "^[0-9]{1,}$";
            var resultado = Regex.Match(inputString, padraoNumeros);
            return (resultado.Success) ? true : false;
        }
    }
}