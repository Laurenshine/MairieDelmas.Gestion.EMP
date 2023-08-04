using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MairieDelmas.Gestion.EMP.Data.Migrations
{
    public partial class Migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corespondance",
                columns: table => new
                {
                    CorespondanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    Objet = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Daterecu = table.Column<DateTime>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Suivi = table.Column<string>(nullable: true),
                    Remarque = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corespondance", x => x.CorespondanceId);
                });

            migrationBuilder.CreateTable(
                name: "Doleance",
                columns: table => new
                {
                    DoleanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(nullable: true),
                    Demande = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateDoloeance = table.Column<DateTime>(nullable: false),
                    Service = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Suivi = table.Column<string>(nullable: true),
                    Remarque = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doleance", x => x.DoleanceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corespondance");

            migrationBuilder.DropTable(
                name: "Doleance");
        }
    }
}
