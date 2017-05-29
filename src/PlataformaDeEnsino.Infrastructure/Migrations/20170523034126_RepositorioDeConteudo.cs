using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlataformaDeEnsino.Infrastructure.Migrations
{
    public partial class RepositorioDeConteudo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdDoCurso = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    NomeDoCurso = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.IdDoCurso);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    IdDoProfessor = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CpfDaPessoa = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    EmailDaPessoa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NomeDaPessoa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SobrenomeDaPessoa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.IdDoProfessor);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    IdDoAluno = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CodigoDaTurma = table.Column<string>(type: "varchar(35)", maxLength: 30, nullable: false),
                    CpfDaPessoa = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    EmailDaPessoa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IdDoCurso = table.Column<int>(nullable: false),
                    NivelDoAluno = table.Column<int>(type: "int(12)", maxLength: 1, nullable: false),
                    NomeDaPessoa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SobrenomeDaPessoa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.IdDoAluno);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_IdDoCurso",
                        column: x => x.IdDoCurso,
                        principalTable: "Curso",
                        principalColumn: "IdDoCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coordenador",
                columns: table => new
                {
                    IdDoCoordenador = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CpfDaPessoa = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    EmailDaPessoa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IdDoCurso = table.Column<int>(nullable: false),
                    NomeDaPessoa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SobrenomeDaPessoa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordenador", x => x.IdDoCoordenador);
                    table.ForeignKey(
                        name: "FK_Coordenador_Curso_IdDoCurso",
                        column: x => x.IdDoCurso,
                        principalTable: "Curso",
                        principalColumn: "IdDoCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    IdDoModulo = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    IdDoCurso = table.Column<int>(nullable: false),
                    NivelDoModulo = table.Column<int>(type: "int(12)", maxLength: 1, nullable: false),
                    NomeDoModulo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.IdDoModulo);
                    table.ForeignKey(
                        name: "FK_Modulo_Curso_IdDoCurso",
                        column: x => x.IdDoCurso,
                        principalTable: "Curso",
                        principalColumn: "IdDoCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    IdDaUnidade = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    DiretorioDaUnidade = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: false),
                    IdDoModulo = table.Column<int>(nullable: false),
                    IdDoProfessor = table.Column<int>(nullable: true),
                    NomeDaUnidade = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.IdDaUnidade);
                    table.ForeignKey(
                        name: "FK_Unidade_Modulo_IdDoModulo",
                        column: x => x.IdDoModulo,
                        principalTable: "Modulo",
                        principalColumn: "IdDoModulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unidade_Professor_IdDoProfessor",
                        column: x => x.IdDoProfessor,
                        principalTable: "Professor",
                        principalColumn: "IdDoProfessor",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdDoCurso",
                table: "Aluno",
                column: "IdDoCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Coordenador_IdDoCurso",
                table: "Coordenador",
                column: "IdDoCurso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modulo_IdDoCurso",
                table: "Modulo",
                column: "IdDoCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdDoModulo",
                table: "Unidade",
                column: "IdDoModulo");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdDoProfessor",
                table: "Unidade",
                column: "IdDoProfessor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Coordenador");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
