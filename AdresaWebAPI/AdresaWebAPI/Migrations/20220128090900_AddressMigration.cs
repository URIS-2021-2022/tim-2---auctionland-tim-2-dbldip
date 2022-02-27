using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdresaWebAPI.Migrations
{
    public partial class AddressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    addressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    addressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.addressID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
