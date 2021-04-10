using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class datecorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProfHouseRentInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LoanStartDate",
                table: "ProfHouseRentInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProfHouseRentInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProfHouseRentInfos",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LoanStartDate",
                table: "ProfHouseRentInfos",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProfHouseRentInfos",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
