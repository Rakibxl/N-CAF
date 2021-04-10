using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class datedbupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedDate",
                table: "ProfISEEInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "ProfISEEInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "ProfISEEInfos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedDate",
                table: "ProfISEEInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "ProfISEEInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "ProfISEEInfos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
