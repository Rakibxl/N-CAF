using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class dbupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "ProfIncomeInfo",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Month",
                table: "ProfIncomeInfo",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Year",
                table: "ProfIncomeInfo",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Month",
                table: "ProfIncomeInfo",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
