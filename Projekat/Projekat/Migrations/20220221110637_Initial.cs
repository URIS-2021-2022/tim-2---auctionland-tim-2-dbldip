using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommissionWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => new { x.CommissionId, x.PersonId });
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PresidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.CommissionId);
                    table.ForeignKey(
                        name: "FK_Commissions_Persons_PresidentId",
                        column: x => x.PresidentId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "CommissionId", "PersonId" },
                values: new object[,]
                {
                    { new Guid("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"), new Guid("1499bf05-df8c-465d-895c-bcc5633a40dd") },
                    { new Guid("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"), new Guid("7d60cc93-0ba3-475b-a36b-f203ebb3281b") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name", "Role", "Surname" },
                values: new object[,]
                {
                    { new Guid("7845cc32-71e2-4336-bb3c-11e6b3699673"), "Nikola", "President", "Bikar" },
                    { new Guid("7d60cc93-0ba3-475b-a36b-f203ebb3281b"), "Jovan", "Ucesnik", "Jovanic" },
                    { new Guid("1499bf05-df8c-465d-895c-bcc5633a40dd"), "Marko", "Ucesnik", "Parcetic" }
                });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "CommissionId", "PresidentId" },
                values: new object[] { new Guid("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"), new Guid("7845cc32-71e2-4336-bb3c-11e6b3699673") });

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_PresidentId",
                table: "Commissions",
                column: "PresidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
