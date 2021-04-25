import { Component, OnInit } from '@angular/core';
import { AccountInfo } from '../../../Shared/Entity/Accounts/accountsInfo';
import { AccountInfoService } from '../../../Shared/Services/Accounts/accountInfo.service';

@Component({
    selector: 'app-account-info-list',
    templateUrl: './account-info-list.component.html',
    styleUrls: ['./account-info-list.component.css']
})
export class AccountInfoListComponent implements OnInit {
    public accountsInfoList: AccountInfo[] = [];
    constructor(private accountInfoService: AccountInfoService) { }

    ngOnInit() {
        this.fnGetAllAccountInfo();
    }

    public fnGetAllAccountInfo() {
        this.accountInfoService.getAllAccountInfo().subscribe((res) => {
            this.accountsInfoList = res.data || [];
        });
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        let record = event.record;
        if (event.action == "new-record") {
            //this.router.navigate([`/job-info/job-info-new/0`]);
        }
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnUpdateYourAccountInfo() {
        this.accountInfoService.syncYourAccountInformation().subcribe((res) => {

        });
    }
    //public ptableSettings: IPTableSetting = {
    //    tableClass: "table table-border ",
    //    tableName: 'Account Information',
    //    tableColDef: [
    //        { headerName: 'Account Number', width: '10%', internalName: 'accountNumber', sort: true, type: "" },
    //        { headerName: 'Account Name', width: '10%', internalName: 'accountName', sort: true, type: "" },
    //        { headerName: 'Start Date', width: '10%', internalName: 'created', sort: true, type: "Date" },
    //        { headerName: 'User Type', width: '10%', internalName: 'endDate', sort: false, type: "Date" },
    //    ],
    //    enabledSearch: true,
    //    enabledSerialNo: true,
    //    pageSize: 15,
    //    enabledPagination: true,
    //    enabledEditDeleteBtn: true,
    //    enabledCellClick: true,
    //    enabledColumnFilter: true,
    //    enabledDataLength: true,
    //    enabledColumnResize: true,
    //    enabledReflow: true,
    //    enabledPdfDownload: true,
    //    enabledExcelDownload: true,
    //    enabledPrint: true,
    //    enabledColumnSetting: true,
    //    enabledRecordCreateBtn: true,
    //    enabledViewDetails: true

    //};

}
