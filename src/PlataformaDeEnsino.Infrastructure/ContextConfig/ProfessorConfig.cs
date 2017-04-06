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
                p.Property(i => i.IdDoProfessor).IsRequired().ValueGeneratedOnAdd();
                p.Property(n => n.NomeDoProfessor).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                p.Property(s => s.SobrenomeDoProfessor).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                p.Property(c => c.CpfDoProfessor).HasColumnType("varchar(20)").HasMaxLength(20);
                p.Property(e => e.EstadoDoProfessor).HasColumnType("tinyint(1)").HasMaxLength(1);
            });
        }
    }
}