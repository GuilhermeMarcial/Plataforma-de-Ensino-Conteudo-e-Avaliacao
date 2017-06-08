using System;
using System.Text.RegularExpressions;
using FluentValidation;
using PlataformaDeEnsino.Presenter.Areas.ViewModels;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators
{
    public class AlunoViewModelValidator : AbstractValidator<AlunoViewModel>
    {
        public AlunoViewModelValidator()
        {
            RuleFor(n => n.NomeDaPessoa)
                .NotEmpty().WithMessage("Informe o nome do aluno")
                .Length(3, 50).WithMessage("O nome deve conter no minino 3 caracteres e no máximo 50")
                .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(s => s.SobrenomeDaPessoa)
                .NotEmpty().WithMessage("Informe o sobrenome do aluno")
                .Length(3, 100).WithMessage("O sobrenome deve conter no minimo 3 caracteres e no maximo 100")
                .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(t => t.CpfDaPessoa)
                .NotEmpty().WithMessage("Informe o CPF")
                .Length(10, 12).WithMessage("Cpf deve conter no minimo 10 caracteres")
                .Matches("^[0-9]{1,}$").WithMessage("O campo só aceita numeros");
            RuleFor(t => t.EmailDaPessoa)
                .NotEmpty().WithMessage("Informe o Email")
                .Length(5, 50).WithMessage("Verifique o tamanho do email")
                .Matches("[A-Za-z0-9\\._-]+@[A-Za-z0-9]+(\\.[A-Za-z]+)*").WithMessage("Informe um email valido");
            RuleFor(c => c.CodigoDaTurma)
                .NotEmpty().WithMessage("Informe o Codigo da Turma")
                .Length(6, 20).WithMessage("O codigo da turma deve conter no minimo 6 caracteres")
                .Matches("^[0-9]{1,}$").WithMessage("O campo só aceita numeros");
            RuleFor(n => n.NivelDoAluno)
                .NotEmpty().WithMessage("Selecione o periodo do aluno")
                .Must(SomenteNumeros);
            RuleFor(t => t.IdDoCurso)
                .NotEmpty().WithMessage("Selecione a turma que o aluno sera matriculado")
                .Must(SomenteNumeros);
        }

        private static bool SomenteNumeros(int input)
        {   
            var inputString = Convert.ToString(input);
            var padraoNumeros = "^[0-9]{1,}$";
            Match resultado = Regex.Match(inputString, padraoNumeros);
            return resultado.Success ? true : false;
        }
    }
}