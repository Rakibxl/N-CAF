using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Addedjobsectionlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobInformations_LU_SectionName_SectionNameId",
                table: "JobInformations");

            migrationBuilder.DropIndex(
                name: "IX_JobInformations_SectionNameId",
                table: "JobInformations");

            migrationBuilder.DropColumn(
                name: "SectionNameId",
                table: "JobInformations");

            migrationBuilder.CreateTable(
                name: "JobSectionLinks",
                columns: table => new
                {
                    JobSectionLinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    JobId = table.Column<int>(nullable: true),
                    JobInformationJobId = table.Column<int>(nullable: true),
                    SectionNameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSectionLinks", x => x.JobSectionLinkId);
                    table.ForeignKey(
                        name: "FK_JobSectionLinks_JobInformations_JobInformationJobId",
                        column: x => x.JobInformationJobId,
                        principalTable: "JobInformations",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSectionLinks_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSectionLinks_LU_SectionName_SectionNameId",
                        column: x => x.SectionNameId,
                        principalTable: "LU_SectionName",
                        principalColumn: "SectionNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSectionLinks_JobInformationJobId",
                table: "JobSectionLinks",
                column: "JobInformationJobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSectionLinks_RecordStatusId",
                table: "JobSectionLinks",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSectionLinks_SectionNameId",
                table: "JobSectionLinks",
                column: "SectionNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSectionLinks");

            migrationBuilder.AddColumn<int>(
                name: "SectionNameId",
                table: "JobInformations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_SectionNameId",
                table: "JobInformations",
                column: "SectionNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobInformations_LU_SectionName_SectionNameId",
                table: "JobInformations",
                column: "SectionNameId",
                principalTable: "LU_SectionName",
                principalColumn: "SectionNameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
