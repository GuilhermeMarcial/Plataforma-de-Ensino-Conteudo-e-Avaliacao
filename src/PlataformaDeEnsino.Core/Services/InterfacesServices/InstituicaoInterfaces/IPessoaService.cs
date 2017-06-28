using System;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces
{
    public interface IPessoaService : IServiceBase<Pessoa> 
    {
        Task<int> InserirPessoaAsync(Pessoa pessoa);
        Task<bool> PessoaExisteCpfAsync(string cpfAntigo, string cpfNovo);
        Task<bool> PessoaExisteEmailAsync(string emailAntigo, string emailNovo);
        Task<bool> ConsularSeCpfExisteAsync(string cpfDaPessoa);
        Task<bool> ConsularSeEmailExisteAsync(string emailDaPessoa);
    }
}