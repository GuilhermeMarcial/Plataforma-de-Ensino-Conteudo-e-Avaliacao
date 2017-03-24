using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.Context
{
    public class ConteudoContext : DbContext
    {
        public ConteudoContext(DbContextOptions<ConteudoContext> opcoes) : base(opcoes)
        {

        }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }

        public void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>().ToTable("Turma");
            modelBuilder.Entity<Modulo>().ToTable("Modulo");
            modelBuilder.Entity<Unidade>().ToTable("Unidade");
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Coordenador>().ToTable("Coordenador");
        }
    }
}