using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class datedbupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProfWorkerInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProfWorkerInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProfInsuranceInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProfInsuranceInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProfWorkerInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProfWorkerInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProfInsuranceInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProfInsuranceInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
