using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class JobSectionLinkmodelcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_JobInformations_JobInformationJobId",
                table: "JobSectionLinks");

            migrationBuilder.DropTable(
                name: "JobInformations");

            migrationBuilder.DropIndex(
                name: "IX_JobSectionLinks_JobInformationJobId",
                table: "JobSectionLinks");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "JobSectionLinks");

            migrationBuilder.DropColumn(
                name: "JobInformationJobId",
                table: "JobSectionLinks");

            migrationBuilder.AddColumn<int>(
                name: "JobInfoId",
                table: "JobSectionLinks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobInfos",
                columns: table => new
                {
                    JobInfoId = table.Column<int>(nullable: false)
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
                    IsEligibleForCityzenShipApply = table.Column<bool>(nullable: false, defaultValue: false),
                    HasUnlimitedResidencePermit = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInfos", x => x.JobInfoId);
                    table.ForeignKey(
                        name: "FK_JobInfos_LU_ISEEClassType_ISEEClassTypeId",
                        column: x => x.ISEEClassTypeId,
                        principalTable: "LU_ISEEClassType",
                        principalColumn: "ISEEClassTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInfos_LU_JobDeliveryType_JobDeliveryTypeId",
                        column: x => x.JobDeliveryTypeId,
                        principalTable: "LU_JobDeliveryType",
                        principalColumn: "JobDeliveryTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobInfos_LU_OccupationType_OccupationTypeId",
                        column: x => x.OccupationTypeId,
                        principalTable: "LU_OccupationType",
                        principalColumn: "OccupationTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSectionLinks_JobInfoId",
                table: "JobSectionLinks",
                column: "JobInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_ISEEClassTypeId",
                table: "JobInfos",
                column: "ISEEClassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_JobDeliveryTypeId",
                table: "JobInfos",
                column: "JobDeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_OccupationTypeId",
                table: "JobInfos",
                column: "OccupationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_JobInfos_JobInfoId",
                table: "JobSectionLinks",
                column: "JobInfoId",
                principalTable: "JobInfos",
                principalColumn: "JobInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_JobInfos_JobInfoId",
                table: "JobSectionLinks");

            migrationBuilder.DropTable(
                name: "JobInfos");

            migrationBuilder.DropIndex(
                name: "IX_JobSectionLinks_JobInfoId",
                table: "JobSectionLinks");

            migrationBuilder.DropColumn(
                name: "JobInfoId",
                table: "JobSectionLinks");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "JobSectionLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobInformationJobId",
                table: "JobSectionLinks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobInformations",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildAgeMax = table.Column<int>(type: "int", nullable: true),
                    ChildAgeMin = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    DaysToBeExpairedNationalId = table.Column<int>(type: "int", nullable: true),
                    DaysToBeExpairedPassport = table.Column<int>(type: "int", nullable: true),
                    DaysToBeExpairedResidencePermit = table.Column<int>(type: "int", nullable: true),
                    DaysToExpairJobContract = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocumentLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    HasUnlimitedResidencePermit = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ISEEClassTypeId = table.Column<int>(type: "int", nullable: true),
                    ISEEMax = table.Column<int>(type: "int", nullable: true),
                    ISEEMin = table.Column<int>(type: "int", nullable: true),
                    IsCommon = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsEligibleForCityzenShipApply = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsEligibleForUnlimitedResidencePermit = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsHighlighted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPregnant = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    JobDeliveryTypeId = table.Column<int>(type: "int", nullable: false),
                    NumberOfChild = table.Column<int>(type: "int", nullable: true),
                    OccupationTypeId = table.Column<int>(type: "int", nullable: true),
                    OperatorTimeFrame = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    SectionList = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSectionLinks_JobInformationJobId",
                table: "JobSectionLinks",
                column: "JobInformationJobId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_JobInformations_JobInformationJobId",
                table: "JobSectionLinks",
                column: "JobInformationJobId",
                principalTable: "JobInformations",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
