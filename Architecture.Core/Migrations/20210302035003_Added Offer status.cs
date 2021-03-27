using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class AddedOfferstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferAcceptedOperatorId",
                table: "OfferInfos");

            migrationBuilder.AddColumn<string>(
                name: "AcceptedOperatorId",
                table: "OfferInfos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentUserId",
                table: "OfferInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidationDate",
                table: "OfferInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidatorId",
                table: "OfferInfos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LU_OfferStatus",
                columns: table => new
                {
                    OfferStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferStatusName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsEmailNotification = table.Column<bool>(nullable: false),
                    IsApplicationNotification = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_OfferStatus", x => x.OfferStatusId);
                });

            migrationBuilder.InsertData(
                table: "LU_OfferStatus",
                columns: new[] { "OfferStatusId", "IsActive", "IsApplicationNotification", "IsEmailNotification", "OfferStatusName" },
                values: new object[,]
                {
                    { 1, true, true, true, "New Offer" },
                    { 2, true, true, true, "Submitted" },
                    { 3, true, true, true, "Pending" },
                    { 4, true, true, true, "Received" },
                    { 5, true, true, true, "Completed" },
                    { 6, true, true, true, "Documents Required" },
                    { 7, true, true, true, "Information Required" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LU_OfferStatus");

            migrationBuilder.DropColumn(
                name: "AcceptedOperatorId",
                table: "OfferInfos");

            migrationBuilder.DropColumn(
                name: "CurrentUserId",
                table: "OfferInfos");

            migrationBuilder.DropColumn(
                name: "ValidationDate",
                table: "OfferInfos");

            migrationBuilder.DropColumn(
                name: "ValidatorId",
                table: "OfferInfos");

            migrationBuilder.AddColumn<string>(
                name: "OfferAcceptedOperatorId",
                table: "OfferInfos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
