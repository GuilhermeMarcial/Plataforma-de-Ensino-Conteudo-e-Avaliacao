using System;
using System.Text.RegularExpressions;
using FluentValidation;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class CoordenadorViewModelValidator : AbstractValidator<CoordenadorViewModel>
    {
        public CoordenadorViewModelValidator()
        {
            RuleFor(n => n.NomeDoCoordenador)
            .NotEmpty().WithMessage("Informe o nome do coordenador")
            .Length(3, 50).WithMessage("O nome deve conter no minino 3 caracteres e no máximo 50")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(s => s.SobrenomeDoCoordenador)
            .NotEmpty().WithMessage("Informe o sobrenome do coordenador")
            .Length(3, 100).WithMessage("O sobrenome deve conter no minimo 3 caracteres e no maximo 100")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(c => c.CpfDoCoordenador)
            .NotEmpty().WithMessage("Informe o cpf do coordenador")
            .Length(14).WithMessage("O cpf deve conter no minimo 11 digitos, sem os caracteres especiais")
            .Matches("^[0-9]{1,}$").WithMessage("O campo aceita somente caracteres numericos");
            RuleFor(c => c.IdDoCurso).NotEmpty().WithMessage("Selecione o curso correspondente ao coordenador")
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