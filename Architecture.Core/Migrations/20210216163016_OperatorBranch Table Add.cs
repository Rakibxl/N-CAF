using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class OperatorBranchTableAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperatorBranches",
                columns: table => new
                {
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<Guid>(nullable: false),
                    BranchInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_OperatorBranches_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorBranches_BranchInfos_BranchInfoId",
                        column: x => x.BranchInfoId,
                        principalTable: "BranchInfos",
                        principalColumn: "BranchInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorBranches_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBranches_ApplicationUserId",
                table: "OperatorBranches",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBranches_BranchInfoId",
                table: "OperatorBranches",
                column: "BranchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBranches_RecordStatusId",
                table: "OperatorBranches",
                column: "RecordStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatorBranches");
        }
    }
}
