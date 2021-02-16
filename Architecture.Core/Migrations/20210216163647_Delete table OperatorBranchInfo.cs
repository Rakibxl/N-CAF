using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class DeletetableOperatorBranchInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(name: "OperatorBranchInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperatorBranchInfos",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchInfoId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecordStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_OperatorBranchInfos_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorBranchInfos_BranchInfos_BranchInfoId",
                        column: x => x.BranchInfoId,
                        principalTable: "BranchInfos",
                        principalColumn: "BranchInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorBranchInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBranchInfos_ApplicationUserId",
                table: "OperatorBranchInfos",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBranchInfos_BranchInfoId",
                table: "OperatorBranchInfos",
                column: "BranchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBranchInfos_RecordStatusId",
                table: "OperatorBranchInfos",
                column: "RecordStatusId");
        }
    }
}
