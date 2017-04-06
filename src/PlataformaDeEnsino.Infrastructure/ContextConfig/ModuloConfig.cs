using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.ContextConfig
{
    public class ModuloConfig
    {
        public static void Modulo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modulo>(m =>
            {
                m.ToTable("Modulo");
                m.HasKey(i => i.IdDoMobulo);
                m.Property(i => i.IdDoMobulo).IsRequired().ValueGeneratedOnAdd();
                m.Property(n => n.NomeDoModulo).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
                m.Property(e => e.EstadoDoModulo).IsRequired().HasColumnType("tinyint(1)").HasMaxLength(1);
                m.HasOne(t => t.Turma).WithMany(t => t.Modulos).HasForeignKey(t => t.IdDaTurma);
            });
        }
    }
}