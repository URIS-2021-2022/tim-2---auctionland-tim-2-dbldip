using Microsoft.EntityFrameworkCore.Migrations;

namespace UgovorOZakupuWebAPI.Migrations
{
    public partial class ForeignAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MaturityDeadline_LeaseAgreementId",
                table: "MaturityDeadline",
                column: "LeaseAgreementId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaturityDeadline_LeaseAgreement_LeaseAgreementId",
                table: "MaturityDeadline",
                column: "LeaseAgreementId",
                principalTable: "LeaseAgreement",
                principalColumn: "LeaseAgreementId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaturityDeadline_LeaseAgreement_LeaseAgreementId",
                table: "MaturityDeadline");

            migrationBuilder.DropIndex(
                name: "IX_MaturityDeadline_LeaseAgreementId",
                table: "MaturityDeadline");
        }
    }
}
