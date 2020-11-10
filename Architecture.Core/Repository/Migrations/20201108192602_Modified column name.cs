using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Repository.Migrations
{
    public partial class Modifiedcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfDocumentInfos_LU_DocumentType_DocumentTypeId",
                table: "ProfDocumentInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDocumentInfos_ProfBasicInfos_ProfileId",
                table: "ProfDocumentInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDocumentInfos_RecordStatus_RecordStatusId",
                table: "ProfDocumentInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfDocumentInfos",
                table: "ProfDocumentInfos");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProfWorkerInfos");

            migrationBuilder.DropColumn(
                name: "PreviousNationality",
                table: "ProfFamilyInfo");

            migrationBuilder.DropColumn(
                name: "EyesColorId",
                table: "ProfBasicInfos");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProfBankInfos");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "ProfDocumentInfos");

            migrationBuilder.RenameTable(
                name: "ProfDocumentInfos",
                newName: "ProfDocumentInfo");

            migrationBuilder.RenameColumn(
                name: "SumittedDate",
                table: "ProfISEEInfos",
                newName: "SubmittedDate");

            migrationBuilder.RenameColumn(
                name: "MontlyIncome",
                table: "ProfIncomeInfo",
                newName: "MonthlyIncome");

            migrationBuilder.RenameColumn(
                name: "PurposeofDocument",
                table: "ProfDocumentInfo",
                newName: "PurposeOfDocument");

            migrationBuilder.RenameIndex(
                name: "IX_ProfDocumentInfos_RecordStatusId",
                table: "ProfDocumentInfo",
                newName: "IX_ProfDocumentInfo_RecordStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfDocumentInfos_ProfileId",
                table: "ProfDocumentInfo",
                newName: "IX_ProfDocumentInfo_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfDocumentInfos_DocumentTypeId",
                table: "ProfDocumentInfo",
                newName: "IX_ProfDocumentInfo_DocumentTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ProfWorkerInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousNationalityId",
                table: "ProfFamilyInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EyeColorId",
                table: "ProfBasicInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ProfBankInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "ProfDocumentInfo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedDate",
                table: "ProfDocumentInfo",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfDocumentInfo",
                table: "ProfDocumentInfo",
                column: "DocumentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_PreviousNationalityId",
                table: "ProfFamilyInfo",
                column: "PreviousNationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_ContractTypeId",
                table: "ProfBasicInfos",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_EyeColorId",
                table: "ProfBasicInfos",
                column: "EyeColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_GenderId",
                table: "ProfBasicInfos",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_MaritalStatusId",
                table: "ProfBasicInfos",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_MotiveTypeId",
                table: "ProfBasicInfos",
                column: "MotiveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_NationalityId",
                table: "ProfBasicInfos",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_OccupationPositionId",
                table: "ProfBasicInfos",
                column: "OccupationPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_OccupationTypeId",
                table: "ProfBasicInfos",
                column: "OccupationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_ContractType_ContractTypeId",
                table: "ProfBasicInfos",
                column: "ContractTypeId",
                principalTable: "LU_ContractType",
                principalColumn: "ContractTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_EyeColor_EyeColorId",
                table: "ProfBasicInfos",
                column: "EyeColorId",
                principalTable: "LU_EyeColor",
                principalColumn: "EyeColorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_Gender_GenderId",
                table: "ProfBasicInfos",
                column: "GenderId",
                principalTable: "LU_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_MeriatalStatus_MaritalStatusId",
                table: "ProfBasicInfos",
                column: "MaritalStatusId",
                principalTable: "LU_MeriatalStatus",
                principalColumn: "MeritalStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_MotiveType_MotiveTypeId",
                table: "ProfBasicInfos",
                column: "MotiveTypeId",
                principalTable: "LU_MotiveType",
                principalColumn: "MotiveTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_Nationality_NationalityId",
                table: "ProfBasicInfos",
                column: "NationalityId",
                principalTable: "LU_Nationality",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_OccupationPosition_OccupationPositionId",
                table: "ProfBasicInfos",
                column: "OccupationPositionId",
                principalTable: "LU_OccupationPosition",
                principalColumn: "OccupationPositionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_OccupationType_OccupationTypeId",
                table: "ProfBasicInfos",
                column: "OccupationTypeId",
                principalTable: "LU_OccupationType",
                principalColumn: "OccupationTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDocumentInfo_LU_DocumentType_DocumentTypeId",
                table: "ProfDocumentInfo",
                column: "DocumentTypeId",
                principalTable: "LU_DocumentType",
                principalColumn: "DocumentTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDocumentInfo_ProfBasicInfos_ProfileId",
                table: "ProfDocumentInfo",
                column: "ProfileId",
                principalTable: "ProfBasicInfos",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDocumentInfo_RecordStatus_RecordStatusId",
                table: "ProfDocumentInfo",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_LU_Nationality_PreviousNationalityId",
                table: "ProfFamilyInfo",
                column: "PreviousNationalityId",
                principalTable: "LU_Nationality",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_ContractType_ContractTypeId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_EyeColor_EyeColorId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_Gender_GenderId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_MeriatalStatus_MaritalStatusId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_MotiveType_MotiveTypeId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_Nationality_NationalityId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_OccupationPosition_OccupationPositionId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_OccupationType_OccupationTypeId",
                table: "ProfBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDocumentInfo_LU_DocumentType_DocumentTypeId",
                table: "ProfDocumentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDocumentInfo_ProfBasicInfos_ProfileId",
                table: "ProfDocumentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfDocumentInfo_RecordStatus_RecordStatusId",
                table: "ProfDocumentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_LU_Nationality_PreviousNationalityId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProfFamilyInfo_PreviousNationalityId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_ContractTypeId",
                table: "ProfBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_EyeColorId",
                table: "ProfBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_GenderId",
                table: "ProfBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_MaritalStatusId",
                table: "ProfBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_MotiveTypeId",
                table: "ProfBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_NationalityId",
                table: "ProfBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_OccupationPositionId",
                table: "ProfBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_OccupationTypeId",
                table: "ProfBasicInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfDocumentInfo",
                table: "ProfDocumentInfo");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProfWorkerInfos");

            migrationBuilder.DropColumn(
                name: "PreviousNationalityId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropColumn(
                name: "EyeColorId",
                table: "ProfBasicInfos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProfBankInfos");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "ProfDocumentInfo");

            migrationBuilder.DropColumn(
                name: "IssuedDate",
                table: "ProfDocumentInfo");

            migrationBuilder.RenameTable(
                name: "ProfDocumentInfo",
                newName: "ProfDocumentInfos");

            migrationBuilder.RenameColumn(
                name: "SubmittedDate",
                table: "ProfISEEInfos",
                newName: "SumittedDate");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "ProfIncomeInfo",
                newName: "MontlyIncome");

            migrationBuilder.RenameColumn(
                name: "PurposeOfDocument",
                table: "ProfDocumentInfos",
                newName: "PurposeofDocument");

            migrationBuilder.RenameIndex(
                name: "IX_ProfDocumentInfo_RecordStatusId",
                table: "ProfDocumentInfos",
                newName: "IX_ProfDocumentInfos_RecordStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfDocumentInfo_ProfileId",
                table: "ProfDocumentInfos",
                newName: "IX_ProfDocumentInfos_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfDocumentInfo_DocumentTypeId",
                table: "ProfDocumentInfos",
                newName: "IX_ProfDocumentInfos_DocumentTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "ProfWorkerInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousNationality",
                table: "ProfFamilyInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EyesColorId",
                table: "ProfBasicInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "ProfBankInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "ProfDocumentInfos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfDocumentInfos",
                table: "ProfDocumentInfos",
                column: "DocumentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDocumentInfos_LU_DocumentType_DocumentTypeId",
                table: "ProfDocumentInfos",
                column: "DocumentTypeId",
                principalTable: "LU_DocumentType",
                principalColumn: "DocumentTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDocumentInfos_ProfBasicInfos_ProfileId",
                table: "ProfDocumentInfos",
                column: "ProfileId",
                principalTable: "ProfBasicInfos",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfDocumentInfos_RecordStatus_RecordStatusId",
                table: "ProfDocumentInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
