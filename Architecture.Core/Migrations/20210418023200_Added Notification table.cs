using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class AddedNotificationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    MessageContent = table.Column<string>(nullable: true),
                    ParentMessageId = table.Column<int>(nullable: true),
                    IsGlobal = table.Column<bool>(nullable: false),
                    MessageFor = table.Column<Guid>(nullable: true),
                    IsSeen = table.Column<bool>(nullable: false),
                    SeenTime = table.Column<DateTime>(nullable: true),
                    OfferInfoId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationInfoId);
                    table.ForeignKey(
                        name: "FK_Notifications_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RecordStatusId",
                table: "Notifications",
                column: "RecordStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
