using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class datedbupdated4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentSrc",
                table: "OfferInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferInfos_OfferStatusId",
                table: "OfferInfos",
                column: "OfferStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferInfos_LU_OfferStatus_OfferStatusId",
                table: "OfferInfos",
                column: "OfferStatusId",
                principalTable: "LU_OfferStatus",
                principalColumn: "OfferStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferInfos_LU_OfferStatus_OfferStatusId",
                table: "OfferInfos");

            migrationBuilder.DropIndex(
                name: "IX_OfferInfos_OfferStatusId",
                table: "OfferInfos");

            migrationBuilder.DropColumn(
                name: "DocumentSrc",
                table: "OfferInfos");
        }
    }
}
