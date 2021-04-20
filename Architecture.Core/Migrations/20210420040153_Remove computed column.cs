using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Removecomputedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Notifications",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GetUtcDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Notifications",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GetUtcDate()");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OfferInfoId",
                table: "Notifications",
                column: "OfferInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_OfferInfos_OfferInfoId",
                table: "Notifications",
                column: "OfferInfoId",
                principalTable: "OfferInfos",
                principalColumn: "OfferInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_OfferInfos_OfferInfoId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_OfferInfoId",
                table: "Notifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GetUtcDate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GetUtcDate()",
                oldClrType: typeof(DateTime));
        }
    }
}
