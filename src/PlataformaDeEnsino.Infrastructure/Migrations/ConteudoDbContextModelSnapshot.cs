using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PlataformaDeEnsino.Infrastructure.Context;

namespace PlataformaDeEnsino.Infrastructure.Migrations
{
    [DbContext(typeof(ConteudoDbContext))]
    partial class ConteudoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Aluno", b =>
                {
                    b.Property<int>("IdDoAluno")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CpfDoAluno")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("EstadoDoAluno")
                        .HasColumnType("tinyint(1)")
                        .HasMaxLength(1);

                    b.Property<int>("IdDaTurma");

                    b.Property<string>("NomeDoAluno")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SobrenomeDoAluno")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdDoAluno");

                    b.HasIndex("IdDaTurma");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Coordenador", b =>
                {
                    b.Property<int>("IdDoCoordenador")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CpfDoCoordenador");

                    b.Property<int>("IdDoCurso");

                    b.Property<string>("NomeDoCoordenador")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("SobrenomeDoCoordenador");

                    b.HasKey("IdDoCoordenador");

                    b.HasIndex("IdDoCurso")
                        .IsUnique();

                    b.ToTable("Coordenador");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Curso", b =>
                {
                    b.Property<int>("IdDoCurso")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeDoCurso")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("QuantidadeDeModulos")
                        .HasColumnType("int(1)")
                        .HasMaxLength(1);

                    b.HasKey("IdDoCurso");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Modulo", b =>
                {
                    b.Property<int>("IdDoMobulo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiretorioDaTurma");

                    b.Property<bool>("EstadoDoModulo")
                        .HasColumnType("tinyint(1)")
                        .HasMaxLength(1);

                    b.Property<int>("IdDaTurma");

                    b.Property<string>("NomeDoModulo")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("IdDoMobulo");

                    b.HasIndex("IdDaTurma");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Professor", b =>
                {
                    b.Property<int>("IdDoProfessor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CpfDoProfessor")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("EstadoDoProfessor")
                        .HasColumnType("tinyint(1)")
                        .HasMaxLength(1);

                    b.Property<string>("NomeDoProfessor")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SobrenomeDoProfessor")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdDoProfessor");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Turma", b =>
                {
                    b.Property<int>("IdDaTurma")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoDaTurma")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("DiretorioDaTurma");

                    b.Property<int>("IdDoCurso");

                    b.HasKey("IdDaTurma");

                    b.HasIndex("IdDoCurso");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Unidade", b =>
                {
                    b.Property<int>("IdDaUnidada")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiretorioDaUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("IdDoModulo");

                    b.Property<int>("IdDoProfessor");

                    b.Property<string>("NomeDaUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("IdDaUnidada");

                    b.HasIndex("IdDoModulo");

                    b.HasIndex("IdDoProfessor");

                    b.ToTable("Unidade");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Aluno", b =>
                {
                    b.HasOne("PlataformaDeEnsino.Core.Entities.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("IdDaTurma")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Coordenador", b =>
                {
                    b.HasOne("PlataformaDeEnsino.Core.Entities.Curso", "Curso")
                        .WithOne("Coordenador")
                        .HasForeignKey("PlataformaDeEnsino.Core.Entities.Coordenador", "IdDoCurso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Modulo", b =>
                {
                    b.HasOne("PlataformaDeEnsino.Core.Entities.Turma", "Turma")
                        .WithMany("Modulos")
                        .HasForeignKey("IdDaTurma")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Turma", b =>
                {
                    b.HasOne("PlataformaDeEnsino.Core.Entities.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("IdDoCurso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Unidade", b =>
                {
                    b.HasOne("PlataformaDeEnsino.Core.Entities.Modulo", "Modulo")
                        .WithMany("Unidades")
                        .HasForeignKey("IdDoModulo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PlataformaDeEnsino.Core.Entities.Professor", "Professor")
                        .WithMany("Unidades")
                        .HasForeignKey("IdDoProfessor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
