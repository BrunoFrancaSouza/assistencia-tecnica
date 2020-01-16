using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistenciaTecnica.Repository.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "Usuarios",
                type: "nvarchar(150)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Setor",
                table: "Usuarios");
        }
    }
}
