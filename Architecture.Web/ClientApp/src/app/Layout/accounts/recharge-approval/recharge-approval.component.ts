import { Component, OnInit } from '@angular/core';
import { Subscription, of } from 'rxjs';
import { take, delay, finalize } from 'rxjs/operators';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';
import { IPTableSetting } from 'src/app/Shared/Modules/p-table';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { RolePermissions } from 'src/app/Shared/Constants/user-role-permission';
import { TransactionRequest } from "../../../Shared/Entity/Accounts/transactionRequest";
import { RechargeService } from "../../../Shared/Services/ClientProfile/recharge.service";

@Component({
    selector: 'app-recharge-approval',
    templateUrl: './recharge-approval.component.html',
    styleUrls: ['./recharge-approval.component.css']
})
export class RechargeApprovalComponent implements OnInit {

    pageSize: number;
    pendingRechargeApprovals: TransactionRequest[];
    hideListView: boolean = true;

    // Subscriptions
    private subscriptions: Subscription[] = [];

    constructor(
        private rechargeService: RechargeService,
        private alertService: AlertService,
        private commonService: CommonService) {
        this.pageSize = commonService.PAGE_SIZE;
    }

    ngOnInit() {
        // First Load
        of(undefined).pipe(take(1), delay(1000)).subscribe(() => {
            this.loadPendingRechargeApprovals();
        });

        if (this.commonService.hasPermission(RolePermissions.UserRoles.Delete)) {
            this.pTableSettings.tableName = 'Recharge History',
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

    ngOnDestroy() {
        this.subscriptions.forEach(el => el.unsubscribe());
    }

    loadPendingRechargeApprovals() {
        this.hideListView = false;
        this.alertService.fnLoading(true);
        const pendingRechargeApprovalSubscription = this.rechargeService.getPendingRechargeApprovals()
            .pipe(finalize(() => { this.alertService.fnLoading(false); }))
            .subscribe(
                (res) => {
                    this.pendingRechargeApprovals = res.data;
                },
                (error) => {
                    console.log(error);
                });
        this.subscriptions.push(pendingRechargeApprovalSubscription);
    }

    public pTableSettings: IPTableSetting = {
        tableID: "recharge-approval-table",
        tableClass: "table table-border ",
        tableName: 'Transaction Request History',
        tableRowIDInternalName: "id",
        tableColDef: [
            { headerName: 'Created By', internalName: 'createdBy', sort: true, type: "" },
            { headerName: 'Amount', internalName: 'amount', sort: true, type: "" },
            { headerName: 'Purpose', internalName: 'purpose', sort: true, type: "" },
            { headerName: 'Status', internalName: 'recordStatus.name', sort: true, type: "" },
            { headerName: 'Date Created', internalName: 'created', sort: true, type: "Date", displayType: "datetime" }
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

    fnPtableCellClick(event: any) {
        if (event.cellName === "approve-item") {
            this.openApprovalModal(event.record.transactionRequestId);
        }
        else if (event.cellName === "reject-item") {
            this.openRejectModal(event.record.transactionRequestId);
        }
    }

    openApprovalModal(transactionRequestId) {
        this.alertService.confirm("Do you want to approve the recharge request?",
            async () => {
                await this.approveRechargeRequestAsync(transactionRequestId);
            },
            () => { }
        );
    }

    async approveRechargeRequestAsync(transactionRequestId) {
        await (await this.rechargeService.approvePendingRechargeRequest(transactionRequestId)).toPromise().then(() => {
            this.alertService.tosterSuccess("Recharge request has been approved successfully");
            this.loadPendingRechargeApprovals();
        }, (error: any) => {
            console.log("Error ", error);
        });
    }

    openRejectModal(transactionRequestId) {
        this.alertService.confirm("Do you want to reject the recharge request?",
            async () => {
                await this.rejectRechargeRequestAsync(transactionRequestId);
            },
            () => { }
        );
    }

    async rejectRechargeRequestAsync(transactionRequestId) {
        await (await this.rechargeService.rejectPendingRechargeRequest(transactionRequestId)).toPromise().then(() => {
            this.alertService.tosterSuccess("Recharge request has been rejected successfully");
            this.loadPendingRechargeApprovals();
        }, (error: any) => {
            console.log("Error ", error);
        });
    }

}