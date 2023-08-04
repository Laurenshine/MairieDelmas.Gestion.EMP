using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MairieDelmas.Gestion.EMP.Data.Migrations
{
    public partial class MigrationEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DatechangementEtat",
                table: "Employe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarque",
                table: "Employe",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    PictureFormat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profil", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profil");

            migrationBuilder.DropColumn(
                name: "DatechangementEtat",
                table: "Employe");

            migrationBuilder.DropColumn(
                name: "Remarque",
                table: "Employe");
        }
    }
}
