using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class ProvinceRequiredissues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Province",
                table: "ProfAddressInfos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProfAddressInfos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProfAddressInfos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "ProfAddressInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfAddressInfos_ProvinceId",
                table: "ProfAddressInfos",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfAddressInfos_LU_Province_ProvinceId",
                table: "ProfAddressInfos",
                column: "ProvinceId",
                principalTable: "LU_Province",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfAddressInfos_LU_Province_ProvinceId",
                table: "ProfAddressInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProfAddressInfos_ProvinceId",
                table: "ProfAddressInfos");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "ProfAddressInfos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProfAddressInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProfAddressInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "ProfAddressInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
