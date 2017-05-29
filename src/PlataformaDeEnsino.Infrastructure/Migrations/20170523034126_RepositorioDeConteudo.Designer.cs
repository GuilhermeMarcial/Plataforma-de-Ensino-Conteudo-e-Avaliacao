using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PlataformaDeEnsino.Infrastructure.Context;

namespace PlataformaDeEnsino.Infrastructure.Migrations
{
    [DbContext(typeof(ConteudoDbContext))]
    [Migration("20170523034126_RepositorioDeConteudo")]
    partial class RepositorioDeConteudo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Aluno", b =>
                {
                    b.Property<int>("IdDoAluno")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoDaTurma")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasMaxLength(30);

                    b.Property<string>("CpfDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("EmailDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("IdDoCurso");

                    b.Property<int>("NivelDoAluno")
                        .HasColumnType("int(12)")
                        .HasMaxLength(1);

                    b.Property<string>("NomeDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SobrenomeDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdDoAluno");

                    b.HasIndex("IdDoCurso");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Coordenador", b =>
                {
                    b.Property<int>("IdDoCoordenador")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CpfDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("EmailDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("IdDoCurso");

                    b.Property<string>("NomeDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SobrenomeDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

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

                    b.HasKey("IdDoCurso");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Modulo", b =>
                {
                    b.Property<int>("IdDoModulo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdDoCurso");

                    b.Property<int>("NivelDoModulo")
                        .HasColumnType("int(12)")
                        .HasMaxLength(1);

                    b.Property<string>("NomeDoModulo")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("IdDoModulo");

                    b.HasIndex("IdDoCurso");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Professor", b =>
                {
                    b.Property<int>("IdDoProfessor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CpfDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("EmailDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NomeDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SobrenomeDaPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdDoProfessor");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Unidade", b =>
                {
                    b.Property<int>("IdDaUnidade")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiretorioDaUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(350)")
                        .HasMaxLength(350);

                    b.Property<int>("IdDoModulo");

                    b.Property<int?>("IdDoProfessor");

                    b.Property<string>("NomeDaUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("IdDaUnidade");

                    b.HasIndex("IdDoModulo");

                    b.HasIndex("IdDoProfessor");

                    b.ToTable("Unidade");
                });

            modelBuilder.Entity("PlataformaDeEnsino.Core.Entities.Aluno", b =>
                {
                    b.HasOne("PlataformaDeEnsino.Core.Entities.Curso", "Curso")
                        .WithMany("Alunos")
                        .HasForeignKey("IdDoCurso")
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
                    b.HasOne("PlataformaDeEnsino.Core.Entities.Curso", "Curso")
                        .WithMany("Modulos")
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
                        .OnDelete(DeleteBehavior.SetNull);
                });
        }
    }
}
