using Microsoft.EntityFrameworkCore.Migrations;

namespace MairieDelmas.Gestion.EMP.Data.Migrations
{
    public partial class migrationCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Employe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeDoleance",
                table: "Doleance",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeCorespondance",
                table: "Corespondance",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Conge",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Employe");

            migrationBuilder.DropColumn(
                name: "CodeDoleance",
                table: "Doleance");

            migrationBuilder.DropColumn(
                name: "CodeCorespondance",
                table: "Corespondance");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Conge");
        }
    }
}
