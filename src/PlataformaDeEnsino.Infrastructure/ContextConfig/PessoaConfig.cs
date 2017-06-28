using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.ContextConfig
{
    public class PessoaConfig
    {
        public static void Pessoa(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(p =>
            {
                p.ToTable("Pessoa");
                p.HasKey(pi => pi.IdDaPessoa);
                p.Property(pi => pi.IdDaPessoa).IsRequired().ValueGeneratedOnAdd();
                p.Property(np => np.NomeDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                p.Property(sp => sp.SobrenomeDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                p.Property(ep => ep.EmailDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                p.Property(cpf => cpf.CpfDaPessoa).IsRequired().HasColumnType("varchar(12)").HasMaxLength(12);
            });
        }
    }
}