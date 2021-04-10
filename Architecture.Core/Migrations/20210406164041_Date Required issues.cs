using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class DateRequiredissues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractStartDate",
                table: "ProfOccupationInfo",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "ProfOccupationInfo",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<int>(
                name: "JobInfoId",
                table: "OfferInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfBasicInfoProfileId",
                table: "OfferInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferInfos_JobInfoId",
                table: "OfferInfos",
                column: "JobInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferInfos_ProfBasicInfoProfileId",
                table: "OfferInfos",
                column: "ProfBasicInfoProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferInfos_JobInfos_JobInfoId",
                table: "OfferInfos",
                column: "JobInfoId",
                principalTable: "JobInfos",
                principalColumn: "JobInfoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferInfos_ProfBasicInfos_ProfBasicInfoProfileId",
                table: "OfferInfos",
                column: "ProfBasicInfoProfileId",
                principalTable: "ProfBasicInfos",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferInfos_JobInfos_JobInfoId",
                table: "OfferInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferInfos_ProfBasicInfos_ProfBasicInfoProfileId",
                table: "OfferInfos");

            migrationBuilder.DropIndex(
                name: "IX_OfferInfos_JobInfoId",
                table: "OfferInfos");

            migrationBuilder.DropIndex(
                name: "IX_OfferInfos_ProfBasicInfoProfileId",
                table: "OfferInfos");

            migrationBuilder.DropColumn(
                name: "JobInfoId",
                table: "OfferInfos");

            migrationBuilder.DropColumn(
                name: "ProfBasicInfoProfileId",
                table: "OfferInfos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractStartDate",
                table: "ProfOccupationInfo",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "ProfOccupationInfo",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
