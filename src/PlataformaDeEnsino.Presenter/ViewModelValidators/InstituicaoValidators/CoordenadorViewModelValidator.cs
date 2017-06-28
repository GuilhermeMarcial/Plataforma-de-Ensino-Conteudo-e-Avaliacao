using System.Threading.Tasks;
using FluentValidation;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Presenter.Coordenadores.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModelValidators.InstituicaoValidators
{
    public class CoordenadorViewModelValidator : AbstractValidator<CoordenadorViewModel>
    {
        private readonly IPessoaAppService _pessoaAppService;
        public CoordenadorViewModelValidator(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;

            RuleFor(cpf => cpf.Pessoa.CpfDaPessoa)
            .NotEmpty().WithMessage("Informe o CPF")
            .Length(10, 12).WithMessage("Cpf deve conter no minimo 10 caracteres")
            .Matches("^[0-9]{1,}$").WithMessage("O campo só aceita numeros")
            .Must(CpfNaoExiste).WithMessage("Cpf já esta em uso");
        }

        private bool CpfNaoExiste(string cpfDaPessoa)
        {
            var resultado = Task.Run(() => _pessoaAppService.ConsularSeCpfExisteAsync(cpfDaPessoa));
            return !resultado.Result;
        }
    }
}