using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Jobinfoauditableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "JobInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "JobInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatusId",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_RecordStatusId",
                table: "JobInfos",
                column: "RecordStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobInfos_LU_RecordStatus_RecordStatusId",
                table: "JobInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobInfos_LU_RecordStatus_RecordStatusId",
                table: "JobInfos");

            migrationBuilder.DropIndex(
                name: "IX_JobInfos_RecordStatusId",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "RecordStatusId",
                table: "JobInfos");
        }
    }
}
