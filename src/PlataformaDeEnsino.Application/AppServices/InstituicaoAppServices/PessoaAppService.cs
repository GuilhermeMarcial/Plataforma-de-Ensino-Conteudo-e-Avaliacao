using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.InstituicaoAppServices
{
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;

        public PessoaAppService(IPessoaService pessoaService) : base(pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task<bool> ConsularSeCpfExisteAsync(string cpfDaPessoa)
        {
            return await _pessoaService.ConsularSeCpfExisteAsync(cpfDaPessoa);
        }

        public async Task<bool> ConsularSeEmailExisteAsync(string emailDaPessoa)
        {
            return await _pessoaService.ConsularSeEmailExisteAsync(emailDaPessoa);
        }

        public async Task<int> InserirPessoaAsync(Pessoa pessoa)
        {
            return await _pessoaService.InserirPessoaAsync(pessoa);
        }

        public async Task<bool> PessoaExisteCpfAsync(string cpfAntigo, string cpfNovo)
        {
            return await _pessoaService.PessoaExisteCpfAsync(cpfAntigo, cpfNovo);
        }

        public async Task<bool> PessoaExisteEmailAsync(string emailAntigo, string emailNovo)
        {
            return await _pessoaService.PessoaExisteEmailAsync(emailAntigo, emailNovo);
        }
    }
}