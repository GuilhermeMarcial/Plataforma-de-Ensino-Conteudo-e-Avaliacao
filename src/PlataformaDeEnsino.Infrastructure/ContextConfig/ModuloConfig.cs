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
                m.HasKey(i => i.IdDoModulo);
                m.Property(i => i.IdDoModulo).IsRequired().ValueGeneratedOnAdd();
                m.Property(n => n.NomeDoModulo).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
                m.Property(e => e.NivelDoModulo).IsRequired().HasColumnType("int(12)").HasMaxLength(1);
                m.HasOne(c => c.Curso).WithMany(c => c.Modulos).HasForeignKey(c => c.IdDoCurso).IsRequired();
            });
        }
    }
}