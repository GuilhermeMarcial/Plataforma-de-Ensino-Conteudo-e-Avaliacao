using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;

namespace PlataformaDeEnsino.Infrastructure.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public async Task<int> InserirPessoaAsync(Pessoa pessoa)
        {
            await context.Pessoas.AddAsync(pessoa);
            context.SaveChanges();
            return pessoa.IdDaPessoa;
        }

        public async Task<bool> ConsularSeCpfExisteAsync(string cpfDaPessoa)
        {
            return await context.Alunos.AsNoTracking().Where(a => a.Pessoa.CpfDaPessoa == cpfDaPessoa).AnyAsync();
        }

        public async Task<bool> ConsularSeEmailExisteAsync(string emailDaPessoa)
        {
            return await context.Alunos.AsNoTracking().Where(a => a.Pessoa.EmailDaPessoa == emailDaPessoa).AnyAsync();
        }

        public async Task<bool> PessoaExisteCpfAsync(string cpfAntigo, string cpfNovo)
        {
            if (!cpfAntigo.Equals(cpfNovo))
            {
                return await context.Alunos.AsNoTracking().Where(a => a.Pessoa.CpfDaPessoa == cpfNovo).AnyAsync();
            }
            
            return false;
        }

        public async Task<bool> PessoaExisteEmailAsync(string emailAntigo, string emailNovo)
        {
            if (!emailAntigo.Equals(emailNovo))
            {
                return await context.Alunos.AsNoTracking().Where(a => a.Pessoa.EmailDaPessoa == emailNovo).AnyAsync();
            }
            
            return false;
        }
    }
}
