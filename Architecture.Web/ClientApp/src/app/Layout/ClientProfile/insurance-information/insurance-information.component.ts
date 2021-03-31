import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profInsuranceInfo } from '../../../Shared/Entity/ClientProfile/profInsuranceInfo';
import { InsuranceInfoService } from '../../../Shared/Services/ClientProfile/insurance-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';


@Component({
  selector: 'app-insurance-information',
  templateUrl: './insurance-information.component.html',
  styleUrls: ['./insurance-information.component.css']
})
export class InsuranceInformationComponent implements OnInit {
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private insuranceService: InsuranceInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
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
        this.getInsuranceInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
           
            this.router.navigate([`/client-profile/insurance-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/insurance-info/${this.profileId}/${event.record.insuranceInfoId}`]);
        }
    }

    public getInsuranceInfos() {
       
        this.insuranceService.getInsuranceInfo(this.profileId).subscribe(
            (success) => {
                this.insuranceInfoList = success.data;
                console.log("get insurance: ", success);
                this.insuranceInfoList.forEach(x => {
                    x.description = x.insuranceType.description || "";
                    x.startDate = this.commonService.getDateToSetForm(x.startDate);
                    x.endDate = this.commonService.getDateToSetForm(x.endDate);

                })    

            },
            error => {
            });

    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Insurance List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'InsuranceType', width: '10%', internalName: 'description', sort: true, type: "" },
            { headerName: 'Insurance Title', width: '10%', internalName: 'insuranceTitle', sort: true, type: "" },
            { headerName: 'Start Date', width: '15%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '15%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'Insurance Amount', width: '10%', internalName: 'insuranceAmount', sort: true, type: "" },
            { headerName: 'InsuranceReturnPercentage', width: '10%', internalName: 'insuranceReturnPercentage', sort: true, type: "" },
            //{ headerName: 'Details', width: '10%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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

    public insuranceInfoList = [
    ];
}
