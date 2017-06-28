using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Task<int> InserirPessoaAsync(Pessoa pessoa);
        Task<bool> ConsularSeCpfExisteAsync(string cpfDaPessoa);
        Task<bool> ConsularSeEmailExisteAsync(string emailDaPessoa);
        Task<bool> PessoaExisteCpfAsync(string cpfAntigo, string cpfNovo);
        Task<bool> PessoaExisteEmailAsync(string emailAntigo, string emailNovo);
    }
}