import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profDelegationInfo } from '../../../Shared/Entity/ClientProfile/profDelegationInfo';
import { DelegationInfoService } from '../../../Shared/Services/ClientProfile/delegation-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-deligation-information',
  templateUrl: './deligation-information.component.html',
  styleUrls: ['./deligation-information.component.css']
})
export class DeligationInformationComponent implements OnInit {
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private delegationService: DelegationInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
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
            this.router.navigate([`/client-profile/deligation-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/deligation-info/${this.profileId}/${event.record.delegationInfoId}`]);
        }
    }

    public getDelegationInfos() {
        debugger;
        this.delegationService.getDelegationInfo(this.profileId).subscribe(
            (success) => {
                console.log("get delegation: ", success);
                for (var i = 0; i < success.data.length; i++) {
                    success.data[i].dateOfBirth = this.commonService.getDateToSetForm(success.data[i].dateOfBirth);
                    success.data[i].documentIssueDate = this.commonService.getDateToSetForm(success.data[i].documentIssueDate);
                    success.data[i].expiryDate = this.commonService.getDateToSetForm(success.data[i].expiryDate);
                }
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
            { headerName: 'Name', width: '7%', internalName: 'name', sort: true, type: "" },
            { headerName: 'Sur Name', width: '7%', internalName: 'surName', sort: true, type: "" },
            { headerName: 'Date Of Birth', width: '7%', internalName: 'dateOfBirth', sort: true, type: "" },
            { headerName: 'TaxCode', width: '7%', internalName: 'taxCode', sort: true, type: "" },
            { headerName: 'Purpose', width: '7%', internalName: 'purpose', sort: true, type: "" },
            { headerName: 'Ref No', width: '7%', internalName: 'refNo', sort: true, type: "" },
            { headerName: 'Document Issue Date', width: '7%', internalName: 'documentIssueDate', sort: true, type: "" },
            { headerName: 'Expiry Date', width: '7%', internalName: 'expiryDate', sort: true, type: "" },
            { headerName: 'Issued By', width: '7%', internalName: 'issuedBy', sort: true, type: "" },
            { headerName: 'Status', width: '7%', internalName: 'status', sort: true, type: "" },        
            //{ headerName: 'Details', width: '7%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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

    public delegationInfoList = [
      
    ];

}
