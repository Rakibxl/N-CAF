import { Component, OnInit } from '@angular/core';
import { TransactionDetail } from '../../../Shared/Entity/Accounts/transactionDetails';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { IPTableSetting } from '../../../Shared/Modules/p-table/p-table.component';
import { TransactionService } from '../../../Shared/Services/Accounts/transaction.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { AuthService } from '../../../Shared/Services/Users/auth.service';

@Component({
  selector: 'app-operator-amount-approval',
  templateUrl: './operator-amount-approval.component.html',
  styleUrls: ['./operator-amount-approval.component.css']
})
export class OperatorAmountApprovalComponent implements OnInit {

    pageSize: number;
    transactionHistory: any[];
    hideListView: boolean = true;

    constructor(
        private transactionService: TransactionService,
        private alertService: AlertService,
        public commonService: CommonService,
        private authService: AuthService) {
        this.pageSize = commonService.PAGE_SIZE;
    }

    async ngOnInit() {
        await this.loadPndingTransactionHistory();
        let applicationUserType = await this.authService.applicationUserTypeId;
        if (applicationUserType==1) {          
                this.pTableSettings.tableColDef = [
                    ...this.pTableSettings.tableColDef,
                    {
                        headerName: '',
                        width: '7%',
                        internalName: 'approve-item',
                        sort: true,
                        type: "custom-button",
                        onClick: 'true',
                        innerBtnIcon: "fa fa-eye text-success",
                        btnTitle: 'Approve'
                    },
                    {
                        headerName: '',
                        width: '7%',
                        internalName: 'reject-item',
                        sort: true,
                        type: "custom-button",
                        onClick: 'true',
                        innerBtnIcon: "fa fa-eye text-success",
                        btnTitle: 'Reject'
                    }
                ];
        }
    }


    public async loadPndingTransactionHistory() {
        await this.transactionService.getPendingTransactionInfo().then(res => {
            this.transactionHistory = res.data || [];
            console.log("success",res);
        });
       
    }

    async fnPtableCellClick(event: any) {
        if (event.cellName === "approve-item") {
            await this.transactionService.approvalRejectOperatorAmount(event.record.transactionId,"approved").then(async res => {
                console.log("success", res);
                await this.loadPndingTransactionHistory();
            });
        }
        else if (event.cellName === "reject-item") {
            await this.transactionService.approvalRejectOperatorAmount(event.record.transactionId, "rejected").then(async res => {
                console.log("success", res);
                await this.loadPndingTransactionHistory();
            });
        }
    }

    public pTableSettings: IPTableSetting = {
        tableID: "recharge-approval-table",
        tableClass: "table table-border ",
        tableName: 'Pending Transaction which offer completed',
        tableRowIDInternalName: "id",
        tableColDef: [
            { headerName: 'Request Date', internalName: 'modified', sort: true, type: "Date", displayType: "datetime" },
            { headerName: 'Code', internalName: 'offerInfo.code', sort: true, type: "" },
            { headerName: 'Description', internalName: 'transactionPurpose', sort: true, type: "" },
            { headerName: 'Amount', internalName: 'amount', sort: true, type: "" },
            { headerName: 'Request By', internalName: 'cratedByName', sort: true, type: "" },
        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 20,
        enabledPagination: true,
        enabledCellClick: true,
        enabledColumnFilter: true,
        enabledDataLength: true,
        enabledColumnResize: true,
        enabledReflow: true
    };

}