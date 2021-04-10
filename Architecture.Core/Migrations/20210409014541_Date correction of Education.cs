using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class DatecorrectionofEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartYear",
                table: "ProfEducationInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndYear",
                table: "ProfEducationInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartYear",
                table: "ProfEducationInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndYear",
                table: "ProfEducationInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
