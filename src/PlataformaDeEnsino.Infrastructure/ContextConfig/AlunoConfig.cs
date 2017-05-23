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
                a.Property(n => n.NomeDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                a.Property(s => s.SobrenomeDaPessoa).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                a.Property(c => c.CpfDaPessoa).IsRequired().HasColumnType("varchar(12)").HasMaxLength(12);
                a.Property(e => e.EmailDaPessoa).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
                a.HasOne(t => t.Curso).WithMany(t => t.Alunos).HasForeignKey(t => t.IdDoCurso).IsRequired();
            });
        }
    }
}