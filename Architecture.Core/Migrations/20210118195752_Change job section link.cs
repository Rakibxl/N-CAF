using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Changejobsectionlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_JobSectionLinks_JobInfos_JobInfoId",
            //    table: "JobSectionLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                table: "JobSectionLinks");

            migrationBuilder.AlterColumn<int>(
                name: "SectionNameId",
                table: "JobSectionLinks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobInfoId",
                table: "JobSectionLinks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_JobInfos_JobInfoId",
                table: "JobSectionLinks",
                column: "JobInfoId",
                principalTable: "JobInfos",
                principalColumn: "JobInfoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                table: "JobSectionLinks",
                column: "SectionNameId",
                principalTable: "LU_SectionName",
                principalColumn: "SectionNameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_JobInfos_JobInfoId",
                table: "JobSectionLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                table: "JobSectionLinks");

            migrationBuilder.AlterColumn<int>(
                name: "SectionNameId",
                table: "JobSectionLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobInfoId",
                table: "JobSectionLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_JobInfos_JobInfoId",
                table: "JobSectionLinks",
                column: "JobInfoId",
                principalTable: "JobInfos",
                principalColumn: "JobInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                table: "JobSectionLinks",
                column: "SectionNameId",
                principalTable: "LU_SectionName",
                principalColumn: "SectionNameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
