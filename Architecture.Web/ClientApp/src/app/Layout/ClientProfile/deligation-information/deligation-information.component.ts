import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profDelegationInfo } from '../../../Shared/Entity/ClientProfile/profDelegationInfo';
import { DelegationInfoService } from '../../../Shared/Services/ClientProfile/delegation-info.service';

@Component({
  selector: 'app-deligation-information',
  templateUrl: './deligation-information.component.html',
  styleUrls: ['./deligation-information.component.css']
})
export class DeligationInformationComponent implements OnInit {

    constructor(private router: Router, private delegationService: DelegationInfoService) { }

    ngOnInit() {
        this.getDelegationInfos();
    }



    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate(['/client-profile/deligation-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/deligation-info/0']);
        }
    }

    public getDelegationInfos() {
        debugger;
        let profileId = 2;
        this.delegationService.getDelegationInfo(profileId).subscribe(
            (success) => {
                console.log("get delegation: ", success);
                this.delegationInfoList = success.data;
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Delegation List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            //{ headerName: 'Delegation Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Name', width: '20%', internalName: 'name', sort: true, type: "" },
            { headerName: 'Sur Name', width: '10%', internalName: 'surName', sort: true, type: "" },
            { headerName: 'Date Of Birth', width: '15%', internalName: 'dateOfBirth', sort: true, type: "" },
            { headerName: 'TaxCode', width: '15%', internalName: 'taxCode', sort: true, type: "" },
            { headerName: 'Purpose', width: '10%', internalName: 'purpose', sort: true, type: "" },
            { headerName: 'Ref No', width: '10%', internalName: 'refNo', sort: true, type: "" },
            { headerName: 'Purpose', width: '10%', internalName: 'purpose', sort: true, type: "" },
            { headerName: 'Document Issue Date', width: '20%', internalName: 'documentIssueDate', sort: true, type: "" },
            { headerName: 'Expiry Date', width: '10%', internalName: 'expiryDate', sort: true, type: "" },
            { headerName: 'Issued By', width: '10%', internalName: 'issuedBy', sort: true, type: "" },
            { headerName: 'Status', width: '10%', internalName: 'status', sort: true, type: "" },        
            { headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 15,
        enabledPagination: false,
        enabledAutoScrolled: true,
        // enabledEditDeleteBtn: true,
        enabledEditDeleteBtn: true,
        //enabledDeleteBtn: true,
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
        enabledTotal: true,
        //enabledCheckbox:true,
        enabledRadioBtn: false,
        tableHeaderVisibility: true,
        // tableFooterVisibility:false,
        pTableStyle: {
            tableOverflowY: true,
            overflowContentHeight: '460px'
        }
    };

    public delegationInfoList = [
      
    ];

}
