using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class addedquestiontableandsectionlookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LU_SectionName",
                columns: table => new
                {
                    SectionNameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionDescription = table.Column<string>(maxLength: 150, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_SectionName", x => x.SectionNameId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionInfos",
                columns: table => new
                {
                    QuestionInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    QuestionDescription = table.Column<string>(maxLength: 500, nullable: false),
                    PageToUrl = table.Column<string>(maxLength: 100, nullable: true),
                    SectionNameId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionInfos", x => x.QuestionInfoId);
                    table.ForeignKey(
                        name: "FK_QuestionInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionInfos_LU_SectionName_SectionNameId",
                        column: x => x.SectionNameId,
                        principalTable: "LU_SectionName",
                        principalColumn: "SectionNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LU_SectionName",
                columns: new[] { "SectionNameId", "IsActive", "SectionDescription" },
                values: new object[,]
                {
                    { 1, true, "Basic Info" },
                    { 2, true, "Occupation Info" },
                    { 3, true, "Family Info" },
                    { 4, true, "Education Info" },
                    { 5, true, "Address Info" },
                    { 6, true, "House Rent Info" },
                    { 7, true, "Document Info" },
                    { 8, true, "Income Info" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionInfos_RecordStatusId",
                table: "QuestionInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionInfos_SectionNameId",
                table: "QuestionInfos",
                column: "SectionNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionInfos");

            migrationBuilder.DropTable(
                name: "LU_SectionName");
        }
    }
}
