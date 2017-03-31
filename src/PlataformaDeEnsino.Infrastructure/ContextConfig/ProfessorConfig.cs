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
                p.Property(n => n.NomeDoProfessor).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            });
        }
    }
}