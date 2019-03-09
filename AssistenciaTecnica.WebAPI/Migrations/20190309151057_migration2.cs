using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistenciaTecnica.WebAPI.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataAlteração",
                table: "Usuarios",
                newName: "DataAlteracao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataAlteracao",
                table: "Usuarios",
                newName: "DataAlteração");
        }
    }
}
