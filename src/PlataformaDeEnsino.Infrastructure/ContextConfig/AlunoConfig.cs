using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.ContextConfig
{
    public class AlunoConfig
    {
        public static void Aluno(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(a =>
            {
                a.ToTable("Aluno");
                a.HasKey(i => i.IdDoAluno);
                a.Property(i => i.IdDoAluno).IsRequired().ValueGeneratedOnAdd();
                a.Property(c => c.CodigoDaTurma).IsRequired().HasColumnType("varchar(35)").HasMaxLength(30);
                a.Property(e => e.NivelDoAluno).IsRequired().HasColumnType("int(12)").HasMaxLength(1);
                a.HasOne(p => p.Pessoa).WithMany(p => p.Alunos).HasForeignKey(p => p.IdDaPessoa).IsRequired();
                a.HasOne(t => t.Curso).WithMany(t => t.Alunos).HasForeignKey(t => t.IdDoCurso).IsRequired();
            });
        }
    }
}