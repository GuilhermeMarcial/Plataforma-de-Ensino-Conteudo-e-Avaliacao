using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.ContextConfig
{
    public class CursoConfig
    {
        public static void Curso(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(c=>{
                c.ToTable("Curso");
                c.HasKey(i => i.IdDoCurso);
                c.Property(i => i.IdDoCurso).IsRequired().ValueGeneratedOnAdd();
                c.Property(n => n.NomeDoCurso).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
            });
        }
    }
}