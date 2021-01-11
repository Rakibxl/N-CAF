using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Updatedjobsectionlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                table: "JobSectionLinks");

            migrationBuilder.AlterColumn<int>(
                name: "SectionNameId",
                table: "JobSectionLinks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobSectionLinks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "JobSectionLinks",
                nullable: false,
                computedColumnSql: "GetUtcDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "JobSectionLinks",
                nullable: false,
                computedColumnSql: "GetUtcDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                table: "JobSectionLinks",
                column: "SectionNameId",
                principalTable: "LU_SectionName",
                principalColumn: "SectionNameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                table: "JobSectionLinks");

            migrationBuilder.AlterColumn<int>(
                name: "SectionNameId",
                table: "JobSectionLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "JobSectionLinks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldComputedColumnSql: "GetUtcDate()");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobSectionLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "JobSectionLinks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldComputedColumnSql: "GetUtcDate()");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                table: "JobSectionLinks",
                column: "SectionNameId",
                principalTable: "LU_SectionName",
                principalColumn: "SectionNameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
