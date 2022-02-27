using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiceWebAPI.Migrations
{
    public partial class MigrationLice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FizickaLica",
                columns: table => new
                {
                    LiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jmbg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizickaLica", x => x.LiceId);
                });

            migrationBuilder.CreateTable(
                name: "KontaktOsoba",
                columns: table => new
                {
                    KontaktOsobaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funkcija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontaktOsoba", x => x.KontaktOsobaId);
                });

            migrationBuilder.CreateTable(
                name: "PravnaLica",
                columns: table => new
                {
                    LiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maticnibroj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontaktOsobaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PravnaLica", x => x.LiceId);
                    table.ForeignKey(
                        name: "FK_PravnaLica_KontaktOsoba_KontaktOsobaId",
                        column: x => x.KontaktOsobaId,
                        principalTable: "KontaktOsoba",
                        principalColumn: "KontaktOsobaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FizickaLica",
                columns: new[] { "LiceId", "AdresaId", "BrojRacuna", "BrojTelefona", "BrojTelefona2", "Email", "Ime", "Jmbg", "Prezime" },
                values: new object[] { new Guid("05b6200f-d5ac-4dce-93e6-9cd5942831a3"), new Guid("1c989ee3-13b2-4d3b-abeb-c4e6343eace7"), "908 ‑ 10501123 ‑ 97", "0694534321", "0694004321", "filip@gmail.com", "Filip", null, "Ivanic" });

            migrationBuilder.InsertData(
                table: "KontaktOsoba",
                columns: new[] { "KontaktOsobaId", "Funkcija", "Ime", "Prezime", "Telefon" },
                values: new object[,]
                {
                    { new Guid("c53b78f6-6b51-46f9-b673-7f7fdf67d6fe"), "Funkcija 1", "Andrija", "Matic", "0641525365" },
                    { new Guid("91af15c5-2aeb-454d-8ac2-af535783444f"), "Funkcija 2", "Marko", "Petrovic", "0691567485" },
                    { new Guid("76473679-fea2-48b1-8dd9-8eace3511f33"), "Funkcija 3", "Nemanja", "Lukic", "0617854963" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PravnaLica_KontaktOsobaId",
                table: "PravnaLica",
                column: "KontaktOsobaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FizickaLica");

            migrationBuilder.DropTable(
                name: "PravnaLica");

            migrationBuilder.DropTable(
                name: "KontaktOsoba");
        }
    }
}
