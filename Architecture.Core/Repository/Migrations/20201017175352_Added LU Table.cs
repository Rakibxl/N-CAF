using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Repository.Migrations
{
    public partial class AddedLUTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfos_LU_Nationality_NationalityId",
                table: "ProfFamilyInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfos_LU_OccupationType_OccupationTypeId",
                table: "ProfFamilyInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfos_ProfBasicInfos_ProfileId",
                table: "ProfFamilyInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfos_RecordStatus_RecordStatusId",
                table: "ProfFamilyInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfos_LU_RelationType_RelationTypeId",
                table: "ProfFamilyInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfos_LU_ResidenceScope_ResidenceScopeId",
                table: "ProfFamilyInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfFamilyInfos",
                table: "ProfFamilyInfos");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordChangedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "ProfFamilyInfos",
                newName: "ProfFamilyInfo");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfos_ResidenceScopeId",
                table: "ProfFamilyInfo",
                newName: "IX_ProfFamilyInfo_ResidenceScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfos_RelationTypeId",
                table: "ProfFamilyInfo",
                newName: "IX_ProfFamilyInfo_RelationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfos_RecordStatusId",
                table: "ProfFamilyInfo",
                newName: "IX_ProfFamilyInfo_RecordStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfos_ProfileId",
                table: "ProfFamilyInfo",
                newName: "IX_ProfFamilyInfo_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfos_OccupationTypeId",
                table: "ProfFamilyInfo",
                newName: "IX_ProfFamilyInfo_OccupationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfos_NationalityId",
                table: "ProfFamilyInfo",
                newName: "IX_ProfFamilyInfo_NationalityId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserStatusId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserTypeId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfFamilyInfo",
                table: "ProfFamilyInfo",
                column: "FamilyInfoId");

            migrationBuilder.CreateTable(
                name: "LU_AppAppUserType",
                columns: table => new
                {
                    AppUserTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserTypeTitle = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_AppAppUserType", x => x.AppUserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_AppUserStatus",
                columns: table => new
                {
                    AppUserStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserStatusTitle = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_AppUserStatus", x => x.AppUserStatusId);
                });

            migrationBuilder.InsertData(
                table: "LU_AppAppUserType",
                columns: new[] { "AppUserTypeId", "AppUserTypeTitle", "IsActive" },
                values: new object[,]
                {
                    { 1, "Client", true },
                    { 2, "Branch User", true },
                    { 3, "Other", true }
                });

            migrationBuilder.InsertData(
                table: "LU_AppUserStatus",
                columns: new[] { "AppUserStatusId", "AppUserStatusTitle", "IsActive" },
                values: new object[,]
                {
                    { 1, "Approved", true },
                    { 2, "Rejected", true },
                    { 3, "Request For Approval", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserStatusId",
                table: "AspNetUsers",
                column: "AppUserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserTypeId",
                table: "AspNetUsers",
                column: "AppUserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LU_AppUserStatus_AppUserStatusId",
                table: "AspNetUsers",
                column: "AppUserStatusId",
                principalTable: "LU_AppUserStatus",
                principalColumn: "AppUserStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LU_AppAppUserType_AppUserTypeId",
                table: "AspNetUsers",
                column: "AppUserTypeId",
                principalTable: "LU_AppAppUserType",
                principalColumn: "AppUserTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_LU_Nationality_NationalityId",
                table: "ProfFamilyInfo",
                column: "NationalityId",
                principalTable: "LU_Nationality",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_LU_OccupationType_OccupationTypeId",
                table: "ProfFamilyInfo",
                column: "OccupationTypeId",
                principalTable: "LU_OccupationType",
                principalColumn: "OccupationTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_ProfBasicInfos_ProfileId",
                table: "ProfFamilyInfo",
                column: "ProfileId",
                principalTable: "ProfBasicInfos",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_RecordStatus_RecordStatusId",
                table: "ProfFamilyInfo",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_LU_RelationType_RelationTypeId",
                table: "ProfFamilyInfo",
                column: "RelationTypeId",
                principalTable: "LU_RelationType",
                principalColumn: "RelationTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_LU_ResidenceScope_ResidenceScopeId",
                table: "ProfFamilyInfo",
                column: "ResidenceScopeId",
                principalTable: "LU_ResidenceScope",
                principalColumn: "ResidenceScopeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LU_AppUserStatus_AppUserStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LU_AppAppUserType_AppUserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_LU_Nationality_NationalityId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_LU_OccupationType_OccupationTypeId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_ProfBasicInfos_ProfileId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_RecordStatus_RecordStatusId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_LU_RelationType_RelationTypeId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_LU_ResidenceScope_ResidenceScopeId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropTable(
                name: "LU_AppAppUserType");

            migrationBuilder.DropTable(
                name: "LU_AppUserStatus");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppUserStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppUserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfFamilyInfo",
                table: "ProfFamilyInfo");

            migrationBuilder.DropColumn(
                name: "AppUserStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "ProfFamilyInfo",
                newName: "ProfFamilyInfos");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfo_ResidenceScopeId",
                table: "ProfFamilyInfos",
                newName: "IX_ProfFamilyInfos_ResidenceScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfo_RelationTypeId",
                table: "ProfFamilyInfos",
                newName: "IX_ProfFamilyInfos_RelationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfo_RecordStatusId",
                table: "ProfFamilyInfos",
                newName: "IX_ProfFamilyInfos_RecordStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfo_ProfileId",
                table: "ProfFamilyInfos",
                newName: "IX_ProfFamilyInfos_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfo_OccupationTypeId",
                table: "ProfFamilyInfos",
                newName: "IX_ProfFamilyInfos_OccupationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfFamilyInfo_NationalityId",
                table: "ProfFamilyInfos",
                newName: "IX_ProfFamilyInfos_NationalityId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PasswordChangedCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfFamilyInfos",
                table: "ProfFamilyInfos",
                column: "FamilyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfos_LU_Nationality_NationalityId",
                table: "ProfFamilyInfos",
                column: "NationalityId",
                principalTable: "LU_Nationality",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfos_LU_OccupationType_OccupationTypeId",
                table: "ProfFamilyInfos",
                column: "OccupationTypeId",
                principalTable: "LU_OccupationType",
                principalColumn: "OccupationTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfos_ProfBasicInfos_ProfileId",
                table: "ProfFamilyInfos",
                column: "ProfileId",
                principalTable: "ProfBasicInfos",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfos_RecordStatus_RecordStatusId",
                table: "ProfFamilyInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfos_LU_RelationType_RelationTypeId",
                table: "ProfFamilyInfos",
                column: "RelationTypeId",
                principalTable: "LU_RelationType",
                principalColumn: "RelationTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfos_LU_ResidenceScope_ResidenceScopeId",
                table: "ProfFamilyInfos",
                column: "ResidenceScopeId",
                principalTable: "LU_ResidenceScope",
                principalColumn: "ResidenceScopeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
