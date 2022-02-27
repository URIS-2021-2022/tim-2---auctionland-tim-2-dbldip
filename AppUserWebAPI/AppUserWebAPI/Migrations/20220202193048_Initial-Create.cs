using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppUserWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    typeOfUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeOfUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.typeOfUserId);
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "typeOfUserId", "typeOfUser" },
                values: new object[,]
                {
                    { new Guid("6ba863f6-0692-4cac-9233-c37d45c077ec"), "Operater" },
                    { new Guid("e9a14b65-9576-4d72-91c3-216fe76c8454"), "Tehnicki sekretar" },
                    { new Guid("b27196e7-3ffd-4b72-b201-1366052b2f71"), "Prva komisija" },
                    { new Guid("8e4314fd-413e-4974-a6ea-c34ac02c2eb9"), "Superuser" },
                    { new Guid("d9257584-a4fd-4503-9755-aa7684399a34"), "Operater Nadmetanja" },
                    { new Guid("4426b5ab-8829-4c84-9b0a-2bd15dbe2a47"), "Licitant" },
                    { new Guid("592fc1b8-6b01-4bde-a65b-5bdcd65d19d3"), "Menadzer" },
                    { new Guid("f6be0101-3d5b-425a-8987-cd5bcfb22fbb"), "Administrator" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
