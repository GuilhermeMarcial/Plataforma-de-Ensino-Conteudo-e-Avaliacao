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
                a.Property(n => n.NomeDoAluno).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                a.HasOne(t => t.Turma).WithMany(t => t.Alunos).HasForeignKey(t => t.IdDaTurma);
            });
        }
    }
}