import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profInsuranceInfo } from '../../../Shared/Entity/ClientProfile/profInsuranceInfo';
import { InsuranceInfoService } from '../../../Shared/Services/ClientProfile/insurance-info.service';

@Component({
  selector: 'app-insurance-information',
  templateUrl: './insurance-information.component.html',
  styleUrls: ['./insurance-information.component.css']
})
export class InsuranceInformationComponent implements OnInit {

    constructor(private router: Router, private insuranceService: InsuranceInfoService) { }

    ngOnInit() {
        this.getInsuranceInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate(['/client-profile/insurance-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/insurance-info/0']);
        }
    }

    public getInsuranceInfos() {
        debugger;
        let profileId = 2;
        this.insuranceService.getInsuranceInfo(profileId).subscribe(
            (success) => {
                console.log("get insurance: ", success);
                this.insuranceInfoList = success.data;
            },
            error => {
            });

    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Insurance List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            //{ headerName: 'Insurance Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            //{ headerName: 'InsuranceType', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Insurance Title', width: '10%', internalName: 'insuranceTitle', sort: true, type: "" },
            { headerName: 'Start Date', width: '15%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '15%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'Insurance Amount', width: '10%', internalName: 'insuranceAmount', sort: true, type: "" },
            { headerName: 'InsuranceReturnPercentage', width: '10%', internalName: 'insuranceReturnPercentage', sort: true, type: "" },
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

    public insuranceInfoList = [
    ];
}
