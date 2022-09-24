using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MairieDelmas.Gestion.EMP.Data.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conge",
                columns: table => new
                {
                    CongeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                        EmployeId  = table.Column<string>(nullable: true),
                    TypeConge = table.Column<string>(nullable: true),
                    DebutConge = table.Column<DateTime>(nullable: false),
                    FinConge = table.Column<DateTime>(nullable: false),
                    ReprendreService = table.Column<DateTime>(nullable: false),
                    Observation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conge", x => x.CongeId);
                    table.ForeignKey(
                       name: "FK_Conge_Employe_EmployeId",
                       column: x => x.EmployeId,
                       principalTable: "Employe",
                       principalColumn: "EmployeId",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employe",
                columns: table => new
                {
                    EmployeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeEmp = table.Column<string>(nullable: true),
                    TypeContrat = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    LieudeNaissance = table.Column<string>(nullable: true),
                    Nationalite = table.Column<string>(nullable: true),
                    PaysdeNaissance = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    SituationFamiliale = table.Column<string>(nullable: true),
                    NombrePersaCharge = table.Column<int>(nullable: false),
                    NombreEnfants = table.Column<int>(nullable: false),
                    NIFCIN = table.Column<string>(nullable: true),
                    Emploi = table.Column<string>(nullable: true),
                    Service = table.Column<string>(nullable: true),
                    Cadre = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: false),
                    Portable = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PersonneAPrevenir = table.Column<string>(nullable: true),
                    PortablePersonneAPrevenir = table.Column<string>(nullable: true),
                    Liens = table.Column<string>(nullable: true),
                    CarteIdentification = table.Column<string>(nullable: true),
                    CV = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    PermisConduire = table.Column<string>(nullable: true),
                    Allergies = table.Column<string>(nullable: true),
                    Gs = table.Column<string>(nullable: true),
                    Maladies = table.Column<string>(nullable: true),
                    Remarques = table.Column<string>(nullable: true),
                    DatederniereVisite = table.Column<DateTime>(nullable: false),
                    DateEntreaLaMairie = table.Column<DateTime>(nullable: false),
                    CompteBancaireBNC = table.Column<string>(nullable: true),
                    AutreFormation = table.Column<string>(nullable: true),
                    EtudeEncour = table.Column<string>(nullable: true),
                    Etat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employe", x => x.EmployeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conge");

            migrationBuilder.DropTable(
                name: "Employe");
        }
    }
}
