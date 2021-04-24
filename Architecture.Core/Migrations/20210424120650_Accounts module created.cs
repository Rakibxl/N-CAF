using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Accountsmodulecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BranchRequiredAmount",
                table: "JobInfos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ClientRequiredAmount",
                table: "JobInfos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatorRequiredAmount",
                table: "JobInfos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "AccountInfos",
                columns: table => new
                {
                    AccountInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 100, nullable: false),
                    AccountName = table.Column<string>(maxLength: 100, nullable: true),
                    MasterId = table.Column<string>(maxLength: 100, nullable: false),
                    AppUserTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfos", x => x.AccountInfoId);
                    table.ForeignKey(
                        name: "FK_AccountInfos_LU_AppUserType_AppUserTypeId",
                        column: x => x.AppUserTypeId,
                        principalTable: "LU_AppUserType",
                        principalColumn: "AppUserTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountInfos_LU_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "LU_RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LU_PaymentType",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_PaymentType", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    TransactionDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    TransactionId = table.Column<int>(nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    Credit = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.TransactionDetailId);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_LU_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "LU_RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    TransactionPurpose = table.Column<string>(maxLength: 500, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    ApprovedBy = table.Column<Guid>(nullable: true),
                    IsAutoAccounting = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_LU_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "LU_RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRequests",
                columns: table => new
                {
                    TransactionRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    Purpose = table.Column<string>(maxLength: 500, nullable: false),
                    ApprovedBy = table.Column<Guid>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    RequestBy = table.Column<Guid>(nullable: true),
                    TransactionId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    PaymentReceivedBy = table.Column<string>(maxLength: 300, nullable: true),
                    PaymentReceivedDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRequests", x => x.TransactionRequestId);
                    table.ForeignKey(
                        name: "FK_TransactionRequests_LU_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "LU_PaymentType",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionRequests_LU_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "LU_RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LU_PaymentType",
                columns: new[] { "PaymentTypeId", "IsActive", "PaymentTypeName" },
                values: new object[,]
                {
                    { 1, true, "Cash" },
                    { 2, true, "Online Payment" },
                    { 3, true, "Paypal Payment" },
                    { 4, true, "Bank Payment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfos_AppUserTypeId",
                table: "AccountInfos",
                column: "AppUserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfos_RecordStatusId",
                table: "AccountInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_RecordStatusId",
                table: "TransactionDetails",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRequests_PaymentTypeId",
                table: "TransactionRequests",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRequests_RecordStatusId",
                table: "TransactionRequests",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RecordStatusId",
                table: "Transactions",
                column: "RecordStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountInfos");

            migrationBuilder.DropTable(
                name: "TransactionDetails");

            migrationBuilder.DropTable(
                name: "TransactionRequests");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "LU_PaymentType");

            migrationBuilder.DropColumn(
                name: "BranchRequiredAmount",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "ClientRequiredAmount",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "OperatorRequiredAmount",
                table: "JobInfos");
        }
    }
}
