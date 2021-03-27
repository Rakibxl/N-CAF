using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class AddedOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatorBranches_BranchInfos_BranchInfoId",
                table: "OperatorBranches");

            migrationBuilder.DropIndex(
                name: "IX_OperatorBranches_BranchInfoId",
                table: "OperatorBranches");

            migrationBuilder.CreateTable(
                name: "OfferInfos",
                columns: table => new
                {
                    OfferInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    JobId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false),
                    OfferAcceptedOperatorId = table.Column<string>(nullable: true),
                    OperatorAcceptedDate = table.Column<DateTime>(nullable: true),
                    OfferStatusId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferInfos", x => x.OfferInfoId);
                    table.ForeignKey(
                        name: "FK_OfferInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferInfos_RecordStatusId",
                table: "OfferInfos",
                column: "RecordStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferInfos");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBranches_BranchInfoId",
                table: "OperatorBranches",
                column: "BranchInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorBranches_BranchInfos_BranchInfoId",
                table: "OperatorBranches",
                column: "BranchInfoId",
                principalTable: "BranchInfos",
                principalColumn: "BranchInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
