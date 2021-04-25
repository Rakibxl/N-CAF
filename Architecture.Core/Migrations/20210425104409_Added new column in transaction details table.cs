using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Addednewcolumnintransactiondetailstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountInfoId",
                table: "TransactionDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_AccountInfoId",
                table: "TransactionDetails",
                column: "AccountInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_AccountInfos_AccountInfoId",
                table: "TransactionDetails",
                column: "AccountInfoId",
                principalTable: "AccountInfos",
                principalColumn: "AccountInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_AccountInfos_AccountInfoId",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_AccountInfoId",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "AccountInfoId",
                table: "TransactionDetails");
        }
    }
}
