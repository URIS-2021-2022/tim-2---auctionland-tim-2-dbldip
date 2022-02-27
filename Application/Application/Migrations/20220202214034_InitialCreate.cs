using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    applicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    applicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    appliedLicitationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    licitationNumber = table.Column<int>(type: "int", nullable: false),
                    licitationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    applierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    applierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    applierAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    priorityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.applicationId);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    priorityID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    priorityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.priorityID);
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "priorityID", "priorityDescription" },
                values: new object[,]
                {
                    { new Guid("4d49c029-1739-49d5-911e-0d7477f45b0c"), "Vlasnik sistema za navodnjavanje" },
                    { new Guid("f4762f51-10fc-4f9f-b408-b4267af5b506"), "Vlasnik zemljista koje se granici sa zemljistem koje se daje u zakup" },
                    { new Guid("f7341e41-84b3-48e7-a82c-1a284b709f84"), "Poljoprivrednik koji je upisan u Registar" },
                    { new Guid("f7341e41-84b3-48e7-a82c-1a284b709f83"), "Vlasnik zemljista koje je najblize zemljistu koje se daje u zakup" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Priorities");
        }
    }
}
