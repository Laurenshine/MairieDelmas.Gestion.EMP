using Microsoft.EntityFrameworkCore.Migrations;

namespace MairieDelmas.Gestion.EMP.Data.Migrations
{
    public partial class CongeModifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Demande",
                table: "Doleance",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emploi",
                table: "Conge",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NifCin",
                table: "Conge",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Conge",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Conge",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Conge",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emploi",
                table: "Conge");

            migrationBuilder.DropColumn(
                name: "NifCin",
                table: "Conge");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Conge");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Conge");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Conge");

            migrationBuilder.AlterColumn<string>(
                name: "Demande",
                table: "Doleance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
