using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Core.Services.InstituicaoServices
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<bool> ConsularSeCpfExisteAsync(string cpfDaPessoa)
        {
            return await _pessoaRepository.ConsularSeCpfExisteAsync(cpfDaPessoa);
        }

        public async Task<bool> ConsularSeEmailExisteAsync(string emailDaPessoa)
        {
            return await _pessoaRepository.ConsularSeEmailExisteAsync(emailDaPessoa);
        }

        public async Task<int> InserirPessoaAsync(Pessoa pessoa)
        {
            return await _pessoaRepository.InserirPessoaAsync(pessoa);
        }

        public async Task<bool> PessoaExisteCpfAsync(string cpfAntigo, string cpfNovo)
        {
            return await _pessoaRepository.PessoaExisteCpfAsync(cpfAntigo, cpfNovo);
        }

        public async Task<bool> PessoaExisteEmailAsync(string emailAntigo, string emailNovo)
        {
            return await _pessoaRepository.PessoaExisteEmailAsync(emailAntigo, emailNovo);
        }
    }
}