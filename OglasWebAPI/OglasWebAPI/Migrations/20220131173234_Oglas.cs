using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OglasWebAPI.Migrations
{
    public partial class Oglas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SluzbeniList",
                columns: table => new
                {
                    SluzbeniListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Broj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SluzbeniList", x => x.SluzbeniListId);
                });

            migrationBuilder.CreateTable(
                name: "Oglas",
                columns: table => new
                {
                    OglasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RokObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oglasivac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oblast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredmetJavneProdaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SluzbeniListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglas", x => x.OglasId);
                    table.ForeignKey(
                        name: "FK_Oglas_SluzbeniList_SluzbeniListId",
                        column: x => x.SluzbeniListId,
                        principalTable: "SluzbeniList",
                        principalColumn: "SluzbeniListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SluzbeniList",
                columns: new[] { "SluzbeniListId", "Broj", "Datum", "Opis" },
                values: new object[] { new Guid("a72ba918-f982-4647-a474-e2a030d4db42"), "mm13jj", new DateTime(2022, 1, 31, 18, 32, 34, 431, DateTimeKind.Local).AddTicks(6186), "Opis sluzbenog lista" });

            migrationBuilder.InsertData(
                table: "SluzbeniList",
                columns: new[] { "SluzbeniListId", "Broj", "Datum", "Opis" },
                values: new object[] { new Guid("d4d339ad-f616-4c2a-a095-b6f74b139521"), "ijkl11", new DateTime(2022, 1, 31, 18, 32, 34, 434, DateTimeKind.Local).AddTicks(5013), "Opis sluzbenog lista je super" });

            migrationBuilder.InsertData(
                table: "SluzbeniList",
                columns: new[] { "SluzbeniListId", "Broj", "Datum", "Opis" },
                values: new object[] { new Guid("09e79dbf-0679-4d8f-a15c-9aad2c86acfa"), "aa331d", new DateTime(2022, 1, 31, 18, 32, 34, 434, DateTimeKind.Local).AddTicks(5063), "Opis sluzbenog lista je odlican" });

            migrationBuilder.InsertData(
                table: "Oglas",
                columns: new[] { "OglasId", "DatumObjave", "Mesto", "Oblast", "Oglasivac", "PredmetJavneProdaje", "RokObjave", "SluzbeniListId" },
                values: new object[] { new Guid("bae63925-7db1-488a-88fd-afd5c88140b1"), new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesto 1", "Oblast 1", "Oglasivac 1", "Predmet javne prodaje 1", new DateTime(2022, 1, 31, 18, 32, 34, 443, DateTimeKind.Local).AddTicks(9383), new Guid("a72ba918-f982-4647-a474-e2a030d4db42") });

            migrationBuilder.InsertData(
                table: "Oglas",
                columns: new[] { "OglasId", "DatumObjave", "Mesto", "Oblast", "Oglasivac", "PredmetJavneProdaje", "RokObjave", "SluzbeniListId" },
                values: new object[] { new Guid("dc0869ed-ea89-47a0-b2da-de9f60418f62"), new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesto 2", "Oblast 2", "Oglasivac 2", "Predmet javne prodaje 2", new DateTime(2022, 1, 31, 18, 32, 34, 444, DateTimeKind.Local).AddTicks(1300), new Guid("d4d339ad-f616-4c2a-a095-b6f74b139521") });

            migrationBuilder.InsertData(
                table: "Oglas",
                columns: new[] { "OglasId", "DatumObjave", "Mesto", "Oblast", "Oglasivac", "PredmetJavneProdaje", "RokObjave", "SluzbeniListId" },
                values: new object[] { new Guid("2aebb81a-2954-40a3-b70d-89d77626a7c4"), new DateTime(2020, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesto 3", "Oblast 3", "Oglasivac 3", "Predmet javne prodaje 3", new DateTime(2022, 1, 31, 18, 32, 34, 444, DateTimeKind.Local).AddTicks(1329), new Guid("09e79dbf-0679-4d8f-a15c-9aad2c86acfa") });

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_SluzbeniListId",
                table: "Oglas",
                column: "SluzbeniListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oglas");

            migrationBuilder.DropTable(
                name: "SluzbeniList");
        }
    }
}
