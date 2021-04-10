using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class datacorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfHouseRentInfos_LU_LoanStatusType_LoanStatusTypeID",
                table: "ProfHouseRentInfos");

            migrationBuilder.RenameColumn(
                name: "LoanStatusTypeID",
                table: "ProfHouseRentInfos",
                newName: "LoanStatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfHouseRentInfos_LoanStatusTypeID",
                table: "ProfHouseRentInfos",
                newName: "IX_ProfHouseRentInfos_LoanStatusTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "LoanStatusTypeId",
                table: "ProfHouseRentInfos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LoanStartDate",
                table: "ProfHouseRentInfos",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractDate",
                table: "ProfHouseRentInfos",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfHouseRentInfos_LU_LoanStatusType_LoanStatusTypeId",
                table: "ProfHouseRentInfos",
                column: "LoanStatusTypeId",
                principalTable: "LU_LoanStatusType",
                principalColumn: "LoanStatusTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfHouseRentInfos_LU_LoanStatusType_LoanStatusTypeId",
                table: "ProfHouseRentInfos");

            migrationBuilder.RenameColumn(
                name: "LoanStatusTypeId",
                table: "ProfHouseRentInfos",
                newName: "LoanStatusTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_ProfHouseRentInfos_LoanStatusTypeId",
                table: "ProfHouseRentInfos",
                newName: "IX_ProfHouseRentInfos_LoanStatusTypeID");

            migrationBuilder.AlterColumn<int>(
                name: "LoanStatusTypeID",
                table: "ProfHouseRentInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LoanStartDate",
                table: "ProfHouseRentInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractDate",
                table: "ProfHouseRentInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfHouseRentInfos_LU_LoanStatusType_LoanStatusTypeID",
                table: "ProfHouseRentInfos",
                column: "LoanStatusTypeID",
                principalTable: "LU_LoanStatusType",
                principalColumn: "LoanStatusTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
