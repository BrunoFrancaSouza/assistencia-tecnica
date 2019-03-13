using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistenciaTecnica.Repository.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Setor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
