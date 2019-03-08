using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistenciaTecnica.WebAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    Empresa = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Perfil = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataAlteração = table.Column<string>(nullable: false),
                    AlteradoPor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
