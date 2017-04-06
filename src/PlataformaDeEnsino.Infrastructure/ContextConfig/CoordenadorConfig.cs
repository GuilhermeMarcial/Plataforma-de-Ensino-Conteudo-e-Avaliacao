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
                c.Property(n => n.NomeDoCoordenador).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
                c.HasOne(t => t.Turma).WithMany(t => t.Coordenadores).HasForeignKey(t => t.IdDaTurma);
            });
        }
    }
}