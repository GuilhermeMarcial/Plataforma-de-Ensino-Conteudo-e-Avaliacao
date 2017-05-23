using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.ContextConfig
{
    public class ProfessorConfig
    {
        public static void Professor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>(p =>
            {
                p.ToTable("Professor");
                p.HasKey(i => i.IdDoProfessor);
                p.Property(n => n.NomeDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                p.Property(s => s.SobrenomeDaPessoa).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                p.Property(c => c.CpfDaPessoa).IsRequired().HasColumnType("varchar(12)").HasMaxLength(12);
                p.Property(e => e.EmailDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                p.Property(i => i.IdDoProfessor).IsRequired().ValueGeneratedOnAdd();
            });
        }
    }
}