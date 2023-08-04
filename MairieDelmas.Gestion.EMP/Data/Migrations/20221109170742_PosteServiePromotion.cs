using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MairieDelmas.Gestion.EMP.Data.Migrations
{
    public partial class PosteServiePromotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poste",
                columns: table => new
                {
                    PosteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPoste = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poste", x => x.PosteId);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    PromotionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    NifCIn = table.Column<string>(nullable: true),
                    AncienPoste = table.Column<string>(nullable: true),
                    AncienService = table.Column<string>(nullable: true),
                    NouveauPoste = table.Column<string>(nullable: true),
                    NouveauService = table.Column<string>(nullable: true),
                    DatePromotion = table.Column<DateTime>(nullable: false),
                    RemarquePromotion = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    EmployeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.PromotionId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomService = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poste");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
