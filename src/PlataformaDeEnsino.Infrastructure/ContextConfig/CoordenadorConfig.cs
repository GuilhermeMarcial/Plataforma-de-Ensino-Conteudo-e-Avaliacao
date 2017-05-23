using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.ContextConfig
{
    public class CoordenadorConfig
    {
        public static void Coordenador(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordenador>(c =>
            {
                c.ToTable("Coordenador");
                c.HasKey(i => i.IdDoCoordenador);
                c.Property(i => i.IdDoCoordenador).IsRequired().ValueGeneratedOnAdd();
                c.Property(n => n.NomeDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                c.Property(s => s.SobrenomeDaPessoa).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                c.Property(cp => cp.CpfDaPessoa).IsRequired().HasColumnType("varchar(12)").HasMaxLength(12);
                c.Property(e => e.EmailDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                c.HasOne(cr => cr.Curso).WithOne(cr => cr.Coordenador).HasForeignKey<Coordenador>(cr => cr.IdDoCurso).IsRequired();
                
            });
        }
    }
}
