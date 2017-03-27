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

        private void TurmaConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>(t => 
            {
                t.ToTable("Turma");
                t.HasKey(i => i.idDaTurma);
                t.Property(i => i.idDaTurma).ValueGeneratedOnAdd();
                t.Property(c => c.codigoDaTurma).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            });
        }

        private void ModuloConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modulo>(m => 
            {
                m.ToTable("Modulo");
                m.HasKey(i => i.idDoMobulo);
                m.Property(i => i.idDoMobulo).IsRequired().ValueGeneratedOnAdd();
                m.Property(n => n.nomeDoModulo).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                m.Property(e => e.estadoDoModulo).IsRequired().HasColumnType("tinyint(1)").HasMaxLength(1);
                m.HasOne(t => t.turma).WithMany(t => t.modulos).HasForeignKey(t => t.idDaTurma);
            });
        }

        private void UnidadeConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unidade>(u => 
            {
                u.ToTable("Unidade");
                u.HasKey(i => i.idDaUnidada);
                u.Property(i => i.idDaUnidada).IsRequired().ValueGeneratedOnAdd();
                u.Property(n => n.nomeDaUnidade).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                u.Property(d => d.DiretorioDaUnidade).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
                u.HasOne(m => m.modulo).WithMany(m => m.unidades).HasForeignKey(m => m.idDoModulo);
                u.HasOne(p => p.professor).WithMany(p => p.unidades).HasForeignKey(p => p.idDoProfessor);
            });
        }

         private void AlunoConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(a => 
            {
                a.ToTable("Aluno");
                a.HasKey(i => i.idDoAluno);
                a.Property(i => i.idDoAluno).IsRequired().ValueGeneratedOnAdd();
                a.Property(n => n.nomeDoAluno).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                a.HasOne(t => t.turma).WithMany(t => t.alunos).HasForeignKey(t => t.idDaTurma);
            });
        }

        private void ProfessorConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>(p => 
            {
                p.ToTable("Professor");
                p.HasKey(i => i.idDoProfessor);
                p.Property(i => i.idDoProfessor).IsRequired().ValueGeneratedOnAdd();
                p.Property(n => n.nomeDoProfessor).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            });
        }

        private void CoordenadorConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordenador>(c => 
            {
                c.ToTable("Professor");
                c.HasKey(i => i.idDoCoordenador);
                c.Property(i => i.idDoCoordenador).IsRequired().ValueGeneratedOnAdd();
                c.Property(n => n.nomeDoCoordenador).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
                c.HasOne(t => t.turma).WithMany(t => t.coordenadores).HasForeignKey(t => t.idDaTurma);
            });
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TurmaConfig(modelBuilder);
            ModuloConfig(modelBuilder);
            UnidadeConfig(modelBuilder);
            AlunoConfig(modelBuilder);
            ProfessorConfig(modelBuilder);
        }
    }
}