using Microsoft.EntityFrameworkCore.Migrations;

namespace LiceWebAPI.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PravnaLica_KontaktOsoba_KontaktOsobaId",
                table: "PravnaLica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PravnaLica",
                table: "PravnaLica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FizickaLica",
                table: "FizickaLica");

            migrationBuilder.RenameTable(
                name: "PravnaLica",
                newName: "PravnoLice");

            migrationBuilder.RenameTable(
                name: "FizickaLica",
                newName: "FizickoLice");

            migrationBuilder.RenameIndex(
                name: "IX_PravnaLica_KontaktOsobaId",
                table: "PravnoLice",
                newName: "IX_PravnoLice_KontaktOsobaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PravnoLice",
                table: "PravnoLice",
                column: "LiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FizickoLice",
                table: "FizickoLice",
                column: "LiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PravnoLice_KontaktOsoba_KontaktOsobaId",
                table: "PravnoLice",
                column: "KontaktOsobaId",
                principalTable: "KontaktOsoba",
                principalColumn: "KontaktOsobaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PravnoLice_KontaktOsoba_KontaktOsobaId",
                table: "PravnoLice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PravnoLice",
                table: "PravnoLice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FizickoLice",
                table: "FizickoLice");

            migrationBuilder.RenameTable(
                name: "PravnoLice",
                newName: "PravnaLica");

            migrationBuilder.RenameTable(
                name: "FizickoLice",
                newName: "FizickaLica");

            migrationBuilder.RenameIndex(
                name: "IX_PravnoLice_KontaktOsobaId",
                table: "PravnaLica",
                newName: "IX_PravnaLica_KontaktOsobaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PravnaLica",
                table: "PravnaLica",
                column: "LiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FizickaLica",
                table: "FizickaLica",
                column: "LiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PravnaLica_KontaktOsoba_KontaktOsobaId",
                table: "PravnaLica",
                column: "KontaktOsobaId",
                principalTable: "KontaktOsoba",
                principalColumn: "KontaktOsobaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
