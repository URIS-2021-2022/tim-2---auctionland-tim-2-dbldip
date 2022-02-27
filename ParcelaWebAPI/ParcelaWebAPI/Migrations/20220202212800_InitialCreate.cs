using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParcelaWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastralMunicipalities",
                columns: table => new
                {
                    cadastralMunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameOfCadastralMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastralMunicipalities", x => x.cadastralMunicipalityId);
                });

            migrationBuilder.CreateTable(
                name: "ParcelParts",
                columns: table => new
                {
                    parcelPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    partSurfaceArea = table.Column<int>(type: "int", nullable: false),
                    partParcelNumber = table.Column<int>(type: "int", nullable: false),
                    partRealEstateListNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelParts", x => x.parcelPartId);
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    parcelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    surfaceArea = table.Column<int>(type: "int", nullable: false),
                    parcelNumber = table.Column<int>(type: "int", nullable: false),
                    realEstateListNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    protectedZoneRealState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    protectedZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    parcelUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jmbg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cadastralMunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameOfCadastralMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parcelPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    partSurfaceArea = table.Column<int>(type: "int", nullable: false),
                    partParcelNumber = table.Column<int>(type: "int", nullable: false),
                    partRealEstateListNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.parcelId);
                });

            migrationBuilder.CreateTable(
                name: "ParcelUsers",
                columns: table => new
                {
                    parcelUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jmbg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelUsers", x => x.parcelUserId);
                });

            migrationBuilder.CreateTable(
                name: "ProtectedZones",
                columns: table => new
                {
                    protectedZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtectedZones", x => x.protectedZoneId);
                });

            migrationBuilder.InsertData(
                table: "CadastralMunicipalities",
                columns: new[] { "cadastralMunicipalityId", "nameOfCadastralMunicipality" },
                values: new object[,]
                {
                    { new Guid("0e0b5e85-f9d8-44e9-8486-6b6702619dc8"), "Cantavir" },
                    { new Guid("e15eb4b2-1e6e-44b7-8d74-c2df17ccfc44"), "Backi Vinogradi" },
                    { new Guid("944256fc-8589-475b-9be1-17ef6e29380b"), "Bikovo" },
                    { new Guid("1554cd0c-bbdd-498c-8a65-88830c99e508"), "Djudjin" },
                    { new Guid("f2e91127-6e56-4f15-bfb1-a6e88efc9ebc"), "Zednik" },
                    { new Guid("a1e35aa8-449e-4081-b59a-f1ba12fba5e7"), "Tavankut" },
                    { new Guid("8532190d-68f8-4465-896f-2a7e652973ce"), "Bajmok" },
                    { new Guid("28937834-ea14-44e9-969f-ef27dc9bfe2f"), "Donji Grad" },
                    { new Guid("d127347a-431b-4f02-999c-162769a5b3df"), "Stari Grad" },
                    { new Guid("a54bee2c-6373-46b9-b25b-d5ba187f7ae5"), "Novi Grad" },
                    { new Guid("b1707be4-a980-4cce-a7eb-a3af44ba36fb"), "Palic" }
                });

            migrationBuilder.InsertData(
                table: "ProtectedZones",
                columns: new[] { "protectedZoneId", "level" },
                values: new object[,]
                {
                    { new Guid("b4817195-2be0-4032-9c3b-c4c153a721dd"), 1 },
                    { new Guid("f7fb9b2f-f2ef-42b7-9920-239424b7fda8"), 2 },
                    { new Guid("39d4bbf0-355d-4228-b8e6-e74b1a4fa62c"), 3 },
                    { new Guid("e192ce2d-d31c-4525-b54c-2459483bf2c1"), 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadastralMunicipalities");

            migrationBuilder.DropTable(
                name: "ParcelParts");

            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "ParcelUsers");

            migrationBuilder.DropTable(
                name: "ProtectedZones");
        }
    }
}
