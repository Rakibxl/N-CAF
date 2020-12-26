using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class ModifyConfugationfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobInformations",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IsCommon = table.Column<bool>(nullable: false, defaultValue: false),
                    JobDeliveryTypeId = table.Column<int>(nullable: false),
                    OperatorTimeFrame = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    IsHighlighted = table.Column<bool>(nullable: false, defaultValue: false),
                    VideoLink = table.Column<string>(maxLength: 250, nullable: true),
                    DocumentLink = table.Column<string>(maxLength: 250, nullable: true),
                    ChildAgeMin = table.Column<int>(nullable: true, defaultValue: 0),
                    ChildAgeMax = table.Column<int>(nullable: true),
                    ISEEMin = table.Column<int>(nullable: true),
                    ISEEMax = table.Column<int>(nullable: true),
                    ISEEClassTypeId = table.Column<int>(nullable: true),
                    IsPregnant = table.Column<bool>(nullable: false, defaultValue: false),
                    OccupationTypeId = table.Column<int>(nullable: true),
                    NumberOfChild = table.Column<int>(nullable: true),
                    DaysToExpairJobContract = table.Column<int>(nullable: true),
                    DaysToBeExpairedResidencePermit = table.Column<int>(nullable: true),
                    IsEligibleForUnlimitedResidencePermit = table.Column<bool>(nullable: false, defaultValue: false),
                    DaysToBeExpairedNationalId = table.Column<int>(nullable: true),
                    DaysToBeExpairedPassport = table.Column<int>(nullable: true),
                    SectionNameId = table.Column<int>(nullable: true),
                    IsEligibleForCityzenShipApply = table.Column<bool>(nullable: false, defaultValue: false),
                    HasUnlimitedResidencePermit = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInformations", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JobInformations_LU_ISEEClassType_ISEEClassTypeId",
                        column: x => x.ISEEClassTypeId,
                        principalTable: "LU_ISEEClassType",
                        principalColumn: "ISEEClassTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInformations_LU_JobDeliveryType_JobDeliveryTypeId",
                        column: x => x.JobDeliveryTypeId,
                        principalTable: "LU_JobDeliveryType",
                        principalColumn: "JobDeliveryTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobInformations_LU_OccupationType_OccupationTypeId",
                        column: x => x.OccupationTypeId,
                        principalTable: "LU_OccupationType",
                        principalColumn: "OccupationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInformations_LU_SectionName_SectionNameId",
                        column: x => x.SectionNameId,
                        principalTable: "LU_SectionName",
                        principalColumn: "SectionNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "LU_JobDeliveryType",
                keyColumn: "JobDeliveryTypeId",
                keyValue: 1,
                column: "JobDeliveryTypeName",
                value: "Normal");

            migrationBuilder.UpdateData(
                table: "LU_JobDeliveryType",
                keyColumn: "JobDeliveryTypeId",
                keyValue: 2,
                column: "JobDeliveryTypeName",
                value: "Standard");

            migrationBuilder.UpdateData(
                table: "LU_JobDeliveryType",
                keyColumn: "JobDeliveryTypeId",
                keyValue: 3,
                column: "JobDeliveryTypeName",
                value: "Urgent");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_ISEEClassTypeId",
                table: "JobInformations",
                column: "ISEEClassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_JobDeliveryTypeId",
                table: "JobInformations",
                column: "JobDeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_OccupationTypeId",
                table: "JobInformations",
                column: "OccupationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_SectionNameId",
                table: "JobInformations",
                column: "SectionNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobInformations");

            migrationBuilder.UpdateData(
                table: "LU_JobDeliveryType",
                keyColumn: "JobDeliveryTypeId",
                keyValue: 1,
                column: "JobDeliveryTypeName",
                value: "Quick");

            migrationBuilder.UpdateData(
                table: "LU_JobDeliveryType",
                keyColumn: "JobDeliveryTypeId",
                keyValue: 2,
                column: "JobDeliveryTypeName",
                value: "Urgent");

            migrationBuilder.UpdateData(
                table: "LU_JobDeliveryType",
                keyColumn: "JobDeliveryTypeId",
                keyValue: 3,
                column: "JobDeliveryTypeName",
                value: "Normal");
        }
    }
}
