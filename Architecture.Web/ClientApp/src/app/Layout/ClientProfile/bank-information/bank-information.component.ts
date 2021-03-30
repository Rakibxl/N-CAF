import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profBankInfo } from '../../../Shared/Entity/ClientProfile/profBankInfo';
import { BankInfoService } from '../../../Shared/Services/ClientProfile/bank-info.service';

@Component({
  selector: 'app-bank-information',
  templateUrl: './bank-information.component.html',
  styleUrls: ['./bank-information.component.css']
})
export class BankInformationComponent implements OnInit {
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private bankService: BankInfoService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        if (this.parentProfileId > 0) { // check the input value if not available then chekc the param
            this.profileId = this.parentProfileId;
            this.ptableSettings.enabledEditDeleteBtn = false;
            this.ptableSettings.enabledEditBtn = true;
            this.ptableSettings.enabledPdfDownload = false;
            this.ptableSettings.enabledExcelDownload = false;
            this.ptableSettings.enabledPrint = false;
            this.ptableSettings.enabledColumnSetting = false;
        } else {
            this.profileId = (+this.route.snapshot.paramMap.get("profId") || 0);
        } 

        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getBankInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/client-profile/bank-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/bank-info/${this.profileId}/${event.record.bankInfoId}`]);
        }
    }

    public getBankInfos() {
        debugger;
        this.bankService.getBankInfo(this.profileId).subscribe(
            (success) => {
                this.bankInfoList = success.data;
                this.bankInfoList.forEach(x => {
                    x.bankDescription = x.bankName.bankDescription || "";
                })    

                console.log("get bank: ", success);
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Bank List',
        tableRowIDInternalName: "bankinfoid",
        tableColDef: [
            { headerName: 'Bank Name', width: '10%', internalName: 'bankDescription', sort: true, type: "" },
            { headerName: 'Branch Name', width: '10%', internalName: 'branchName', sort: true, type: "" },
            { headerName: 'Account Number', width: '15%', internalName: 'accountNumber', sort: true, type: "" },
            { headerName: 'Swift Number', width: '15%', internalName: 'swiftNumber', sort: true, type: "" },            
            { headerName: 'Status', width: '15%', internalName: 'status', sort: true, type: "" },            
            //{ headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 15,
        enabledPagination: true,
        enabledEditDeleteBtn: true,
        enabledCellClick: true,
        enabledColumnFilter: true,
        enabledDataLength: true,
        enabledColumnResize: true,
        enabledReflow: true,
        enabledPdfDownload: true,
        enabledExcelDownload: true,
        enabledPrint: true,
        enabledColumnSetting: true,
        enabledRecordCreateBtn: true,
        enabledViewDetails: true
    };

    public bankInfoList = [
       
    ];

}
