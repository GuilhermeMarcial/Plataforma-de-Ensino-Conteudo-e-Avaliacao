using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Infrastructure.ContextConfig;

namespace PlataformaDeEnsino.Infrastructure.Context
{
    public class ConteudoDbContext : DbContext
    {
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }

        public ConteudoDbContext() : base()
        {

        }

        public ConteudoDbContext(DbContextOptions<ConteudoDbContext> opcoes) : base(opcoes)
        {

        }
        public void Commit()
        {
            SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            TurmaConfig.Turma(builder);
            ModuloConfig.Modulo(builder);
            UnidadeConfig.Unidade(builder);
            AlunoConfig.Aluno(builder);
            ProfessorConfig.Professor(builder);
            CoordenadorConfig.Coordenador(builder);
        }

    }
}