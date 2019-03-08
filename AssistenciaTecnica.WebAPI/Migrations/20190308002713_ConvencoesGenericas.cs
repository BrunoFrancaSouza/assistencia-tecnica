using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistenciaTecnica.WebAPI.Migrations
{
    public partial class ConvencoesGenericas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Empresa",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DataAlteração",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AlteradoPor",
                table: "Usuarios",
                type: "NVARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Empresa",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "DataAlteração",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "AlteradoPor",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)");
        }
    }
}
