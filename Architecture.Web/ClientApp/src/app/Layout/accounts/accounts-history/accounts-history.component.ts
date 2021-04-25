import { Component, OnInit } from '@angular/core';
import { Subscription, of } from 'rxjs';
import { take, delay, finalize } from 'rxjs/operators';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';
import { IPTableSetting } from 'src/app/Shared/Modules/p-table';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { RechargeService } from "../../../Shared/Services/ClientProfile/recharge.service";
import { TransactionDetail } from "../../../Shared/Entity/Accounts/transactionDetails";

@Component({
    selector: 'app-accounts-history',
    templateUrl: './accounts-history.component.html',
    styleUrls: ['./accounts-history.component.css']
})

export class AccountsHistoryComponent implements OnInit {

    pageSize: number;
    transactionHistory: TransactionDetail[];
    hideListView: boolean = true;

    // Subscriptions
    private subscriptions: Subscription[] = [];

    constructor(
        private rechargeService: RechargeService,
        private alertService: AlertService,
        public commonService: CommonService) {
        this.pageSize = commonService.PAGE_SIZE;
    }

    ngOnInit() {
        // First Load
        of(undefined).pipe(take(1), delay(1000)).subscribe(() => {
            this.loadAccountTransactionHistory();
        });
    }

    ngOnDestroy() {
        this.subscriptions.forEach(el => el.unsubscribe());
    }

    loadAccountTransactionHistory() {
        this.hideListView = false;
        this.alertService.fnLoading(true);
        const transferHistorySubscription = this.rechargeService.getTransactionHistory()
            .pipe(finalize(() => { this.alertService.fnLoading(false); }))
            .subscribe(
                (res) => {
                    this.transactionHistory = res.data;
                },
                (error) => {
                    console.log(error);
                });
        this.subscriptions.push(transferHistorySubscription);
    }

    public pTableSettings: IPTableSetting = {
        tableID: "recharge-approval-table",
        tableClass: "table table-border ",
        tableName: 'Transaction History',
        tableRowIDInternalName: "id",
        tableColDef: [
            { headerName: 'Date Created', internalName: 'created', sort: true, type: "Date", displayType: "datetime" },
            { headerName: 'Debit', internalName: 'debit', sort: true, type: "" },
            { headerName: 'Credit', internalName: 'credit', sort: true, type: "" },
            { headerName: 'Purpose', internalName: 'purpose', sort: true, type: "" },
            { headerName: 'Status', internalName: 'recordStatus.name', sort: true, type: "" },
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