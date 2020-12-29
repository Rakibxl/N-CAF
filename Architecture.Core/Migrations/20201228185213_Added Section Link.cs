using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class AddedSectionLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionLinks",
                columns: table => new
                {
                    SectionLinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    ActionLink = table.Column<string>(maxLength: 100, nullable: false),
                    SectionNameId = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionLinks", x => x.SectionLinkId);
                    table.ForeignKey(
                        name: "FK_SectionLinks_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionLinks_LU_SectionName_SectionNameId",
                        column: x => x.SectionNameId,
                        principalTable: "LU_SectionName",
                        principalColumn: "SectionNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionLinks_RecordStatusId",
                table: "SectionLinks",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionLinks_SectionNameId",
                table: "SectionLinks",
                column: "SectionNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionLinks");
        }
    }
}
