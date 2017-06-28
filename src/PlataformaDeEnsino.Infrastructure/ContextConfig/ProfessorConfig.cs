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
                p.HasOne(pe => pe.Pessoa).WithMany(pe => pe.Professores).HasForeignKey(pe => pe.IdDaPessoa).IsRequired();
            });
        }
    }
}