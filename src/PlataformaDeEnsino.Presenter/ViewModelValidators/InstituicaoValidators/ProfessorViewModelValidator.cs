using System.Threading.Tasks;
using FluentValidation;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators.InstituicaoValidators
{
    public class ProfessorViewModelValidator : AbstractValidator<ProfessorViewModel>
    {
        public IPessoaAppService _pessoaAppService;
        public ProfessorViewModelValidator(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
            
            RuleFor(n => n.Pessoa.NomeDaPessoa)
            .NotEmpty().WithMessage("Informe o nome do professor")
            .Length(3, 50).WithMessage("O nome deve conter no minino 3 caracteres e no máximo 50")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(s => s.Pessoa.SobrenomeDaPessoa)
            .NotEmpty().WithMessage("Informe o sobrenome do professor")
            .Length(3, 100).WithMessage("O sobrenome deve conter no minimo 3 caracteres e no maximo 100")
            .Matches("[a-zA-Z\u00C0-\u00FF]+").WithMessage("O campo aceita somente caracteres literais");
            RuleFor(t => t.Pessoa.CpfDaPessoa)
            .NotEmpty().WithMessage("Informe o CPF")
            .Length(10, 12).WithMessage("Cpf deve conter no minimo 10 a 12 caracteres")
            .Matches("^[0-9]{1,}$").WithMessage("O campo só aceita numeros")
            .Must(CpfNaoExiste).WithMessage("Cpf já esta em uso");
            RuleFor(t => t.Pessoa.EmailDaPessoa)
            .NotEmpty().WithMessage("Informe o Email")
            .Length(5, 50).WithMessage("Verifique o tamanho do email")
            .Matches("[A-Za-z0-9\\._-]+@[A-Za-z0-9]+(\\.[A-Za-z]+)*").WithMessage("Informe um email valido")
            .Must(EmailNaoExiste).WithMessage("E-mail já esta em uso");
        }

        private bool CpfNaoExiste(string cpfDaPessoa)
        {
            var resultado = Task.Run(() => _pessoaAppService.ConsularSeCpfExisteAsync(cpfDaPessoa));
            return !resultado.Result;
        }
        private bool EmailNaoExiste(string emailDaPessoa)
        {
            var resultado = Task.Run(() => _pessoaAppService.ConsularSeEmailExisteAsync(emailDaPessoa));
            return !resultado.Result;
        }
    }
}