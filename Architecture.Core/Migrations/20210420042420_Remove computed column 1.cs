using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Removecomputedcolumn1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "OfferInfos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GetUtcDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "OfferInfos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GetUtcDate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "OfferInfos",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GetUtcDate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "OfferInfos",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GetUtcDate()",
                oldClrType: typeof(DateTime));
        }
    }
}
