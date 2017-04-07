using System;
using System.Text.RegularExpressions;
using FluentValidation;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class AlunoViewModelValidator : AbstractValidator<AlunoViewModel>
    {
        public AlunoViewModelValidator()
        {
            RuleFor(n => n.NomeDoAluno)
            .NotEmpty().WithMessage("Informe o nome do aluno")
            .Length(3, 50).WithMessage("O nome deve conter no minino 3 caracteres e no máximo 50")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(s => s.SobrenomeDoAluno)
            .NotEmpty().WithMessage("Informe o sobrenome do aluno")
            .Length(3, 100).WithMessage("O sobrenome deve conter no minimo 3 caracteres e no maximo 100")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(c => c.CpfDoAluno)
            .NotEmpty().WithMessage("Informe o CPF do aluno")
            .Length(14).WithMessage("O cpf deve conter no minimo 11 digitos, sem os caracteres especiais")
            .Matches("^[0-9]{1,}$").WithMessage("O campo aceita somente caracteres numericos");
            RuleFor(t => t.IdDaTurma)
            .NotEmpty().WithMessage("Selecione a turma que o aluno sera matriculado")
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