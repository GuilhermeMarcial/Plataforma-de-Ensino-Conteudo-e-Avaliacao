using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.ContextConfig
{
    public class TurmaConfig
    {
        public static void Turma(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>(t =>
            {
                t.ToTable("Turma");
                t.HasKey(i => i.IdDaTurma);
                t.Property(i => i.IdDaTurma).ValueGeneratedOnAdd();
                t.Property(c => c.CodigoDaTurma).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            });
        }
    }
}