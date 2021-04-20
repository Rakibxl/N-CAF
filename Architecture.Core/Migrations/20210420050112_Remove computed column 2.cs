using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Removecomputedcolumn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchInfos_RecordStatus_RecordStatusId",
                table: "BranchInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_RecordStatus_RecordStatusId",
                table: "JobSectionLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_RecordStatus_RecordStatusId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferInfos_RecordStatus_RecordStatusId",
                table: "OfferInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorBranches_RecordStatus_RecordStatusId",
                table: "OperatorBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfAddressInfos_RecordStatus_RecordStatusId",
                table: "ProfAddressInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfAssetInfos_RecordStatus_RecordStatusId",
                table: "ProfAssetInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBankInfos_RecordStatus_RecordStatusId",
                table: "ProfBankInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_RecordStatus_RecordStatusId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDelegationInfos_RecordStatus_RecordStatusId",
                table: "ProfDelegationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDocumentInfo_RecordStatus_RecordStatusId",
                table: "ProfDocumentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfEducationInfos_RecordStatus_RecordStatusId",
                table: "ProfEducationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_RecordStatus_RecordStatusId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfHouseRentInfos_RecordStatus_RecordStatusId",
                table: "ProfHouseRentInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfIncomeInfo_RecordStatus_RecordStatusId",
                table: "ProfIncomeInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfInsuranceInfos_RecordStatus_RecordStatusId",
                table: "ProfInsuranceInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfISEEInfos_RecordStatus_RecordStatusId",
                table: "ProfISEEInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfLegalInfos_RecordStatus_RecordStatusId",
                table: "ProfLegalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfMovementInfos_RecordStatus_RecordStatusId",
                table: "ProfMovementInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfOccupationInfo_RecordStatus_RecordStatusId",
                table: "ProfOccupationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfWorkerInfos_RecordStatus_RecordStatusId",
                table: "ProfWorkerInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInfos_RecordStatus_RecordStatusId",
                table: "QuestionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionLinks_RecordStatus_RecordStatusId",
                table: "SectionLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordStatus",
                table: "RecordStatus");

            migrationBuilder.RenameTable(
                name: "RecordStatus",
                newName: "LU_RecordStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LU_RecordStatus",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LU_RecordStatus",
                table: "LU_RecordStatus",
                column: "RecordStatusId");

            migrationBuilder.InsertData(
                table: "LU_RecordStatus",
                columns: new[] { "RecordStatusId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Active" },
                    { 2, true, "New" },
                    { 3, true, "Deleted" },
                    { 4, true, "Waiting for Approval" },
                    { 5, true, "Approved" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BranchInfos_LU_RecordStatus_RecordStatusId",
                table: "BranchInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_LU_RecordStatus_RecordStatusId",
                table: "JobSectionLinks",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_LU_RecordStatus_RecordStatusId",
                table: "Notifications",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferInfos_LU_RecordStatus_RecordStatusId",
                table: "OfferInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorBranches_LU_RecordStatus_RecordStatusId",
                table: "OperatorBranches",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfAddressInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfAddressInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfAssetInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfAssetInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBankInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfBankInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfBasicInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDelegationInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfDelegationInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDocumentInfo_LU_RecordStatus_RecordStatusId",
                table: "ProfDocumentInfo",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfEducationInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfEducationInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_LU_RecordStatus_RecordStatusId",
                table: "ProfFamilyInfo",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfHouseRentInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfHouseRentInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfIncomeInfo_LU_RecordStatus_RecordStatusId",
                table: "ProfIncomeInfo",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfInsuranceInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfInsuranceInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfISEEInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfISEEInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfLegalInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfLegalInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfMovementInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfMovementInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfOccupationInfo_LU_RecordStatus_RecordStatusId",
                table: "ProfOccupationInfo",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfWorkerInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfWorkerInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInfos_LU_RecordStatus_RecordStatusId",
                table: "QuestionInfos",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionLinks_LU_RecordStatus_RecordStatusId",
                table: "SectionLinks",
                column: "RecordStatusId",
                principalTable: "LU_RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchInfos_LU_RecordStatus_RecordStatusId",
                table: "BranchInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSectionLinks_LU_RecordStatus_RecordStatusId",
                table: "JobSectionLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_LU_RecordStatus_RecordStatusId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferInfos_LU_RecordStatus_RecordStatusId",
                table: "OfferInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorBranches_LU_RecordStatus_RecordStatusId",
                table: "OperatorBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfAddressInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfAddressInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfAssetInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfAssetInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBankInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfBankInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDelegationInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfDelegationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDocumentInfo_LU_RecordStatus_RecordStatusId",
                table: "ProfDocumentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfEducationInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfEducationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_LU_RecordStatus_RecordStatusId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfHouseRentInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfHouseRentInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfIncomeInfo_LU_RecordStatus_RecordStatusId",
                table: "ProfIncomeInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfInsuranceInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfInsuranceInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfISEEInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfISEEInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfLegalInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfLegalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfMovementInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfMovementInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfOccupationInfo_LU_RecordStatus_RecordStatusId",
                table: "ProfOccupationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfWorkerInfos_LU_RecordStatus_RecordStatusId",
                table: "ProfWorkerInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInfos_LU_RecordStatus_RecordStatusId",
                table: "QuestionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionLinks_LU_RecordStatus_RecordStatusId",
                table: "SectionLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LU_RecordStatus",
                table: "LU_RecordStatus");

            migrationBuilder.DeleteData(
                table: "LU_RecordStatus",
                keyColumn: "RecordStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LU_RecordStatus",
                keyColumn: "RecordStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LU_RecordStatus",
                keyColumn: "RecordStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LU_RecordStatus",
                keyColumn: "RecordStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LU_RecordStatus",
                keyColumn: "RecordStatusId",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "LU_RecordStatus",
                newName: "RecordStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RecordStatus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordStatus",
                table: "RecordStatus",
                column: "RecordStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchInfos_RecordStatus_RecordStatusId",
                table: "BranchInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSectionLinks_RecordStatus_RecordStatusId",
                table: "JobSectionLinks",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_RecordStatus_RecordStatusId",
                table: "Notifications",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferInfos_RecordStatus_RecordStatusId",
                table: "OfferInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorBranches_RecordStatus_RecordStatusId",
                table: "OperatorBranches",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfAddressInfos_RecordStatus_RecordStatusId",
                table: "ProfAddressInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfAssetInfos_RecordStatus_RecordStatusId",
                table: "ProfAssetInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBankInfos_RecordStatus_RecordStatusId",
                table: "ProfBankInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_RecordStatus_RecordStatusId",
                table: "ProfBasicInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDelegationInfos_RecordStatus_RecordStatusId",
                table: "ProfDelegationInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDocumentInfo_RecordStatus_RecordStatusId",
                table: "ProfDocumentInfo",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfEducationInfos_RecordStatus_RecordStatusId",
                table: "ProfEducationInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_RecordStatus_RecordStatusId",
                table: "ProfFamilyInfo",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfHouseRentInfos_RecordStatus_RecordStatusId",
                table: "ProfHouseRentInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfIncomeInfo_RecordStatus_RecordStatusId",
                table: "ProfIncomeInfo",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfInsuranceInfos_RecordStatus_RecordStatusId",
                table: "ProfInsuranceInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfISEEInfos_RecordStatus_RecordStatusId",
                table: "ProfISEEInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfLegalInfos_RecordStatus_RecordStatusId",
                table: "ProfLegalInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfMovementInfos_RecordStatus_RecordStatusId",
                table: "ProfMovementInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfOccupationInfo_RecordStatus_RecordStatusId",
                table: "ProfOccupationInfo",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfWorkerInfos_RecordStatus_RecordStatusId",
                table: "ProfWorkerInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInfos_RecordStatus_RecordStatusId",
                table: "QuestionInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionLinks_RecordStatus_RecordStatusId",
                table: "SectionLinks",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
