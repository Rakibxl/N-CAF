using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class ProvinceLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "OfferInfos",
                nullable: false,
                computedColumnSql: "GetUtcDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "OfferInfos",
                nullable: false,
                computedColumnSql: "GetUtcDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "LU_Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_Province", x => x.ProvinceId);
                });

            migrationBuilder.InsertData(
                table: "LU_Province",
                columns: new[] { "ProvinceId", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "MI", "MILAN", true },
                    { 2, "CO", "COMO", true }
                });

            migrationBuilder.InsertData(
                table: "LU_SectionName",
                columns: new[] { "SectionNameId", "IsActive", "SectionDescription" },
                values: new object[,]
                {
                    { 9, true, "Movement Info" },
                    { 10, true, "Legal Info" },
                    { 11, true, "Insurance Info" },
                    { 12, true, "Bank Info" },
                    { 13, true, "Worker Info" },
                    { 14, true, "Asset Info" },
                    { 15, true, "Deligation Info" },
                    { 16, true, "ISEE Info" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LU_Province");

            migrationBuilder.DeleteData(
                table: "LU_SectionName",
                keyColumn: "SectionNameId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LU_SectionName",
                keyColumn: "SectionNameId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LU_SectionName",
                keyColumn: "SectionNameId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LU_SectionName",
                keyColumn: "SectionNameId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LU_SectionName",
                keyColumn: "SectionNameId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LU_SectionName",
                keyColumn: "SectionNameId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LU_SectionName",
                keyColumn: "SectionNameId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LU_SectionName",
                keyColumn: "SectionNameId",
                keyValue: 16);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "OfferInfos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldComputedColumnSql: "GetUtcDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "OfferInfos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldComputedColumnSql: "GetUtcDate()");
        }
    }
}
