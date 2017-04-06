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
                a.Property(n => n.NomeDoAluno).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                a.Property(s => s.SobrenomeDoAluno).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                a.Property(c => c.CpfDoAluno).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
                a.Property(e => e.EstadoDoAluno).IsRequired().HasColumnType("tinyint(1)").HasMaxLength(1);
                a.HasOne(t => t.Turma).WithMany(t => t.Alunos).HasForeignKey(t => t.IdDaTurma);
            });
        }
    }
}