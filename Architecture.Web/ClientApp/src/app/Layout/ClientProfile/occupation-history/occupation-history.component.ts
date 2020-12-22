import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profOccupationInfo } from '../../../Shared/Entity/ClientProfile/profOccupationInfo';
import { OccupationInfoService } from '../../../Shared/Services/ClientProfile/occupation-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-occupation-history',
  templateUrl: './occupation-history.component.html',
  styleUrls: ['./occupation-history.component.css']
})
export class OccupationHistoryComponent implements OnInit {

    constructor(private router: Router, private occupationService: OccupationInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;
    public contractType = [];

    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        debugger;
        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }

        this.getOccupationInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/client-profile/occupation/${this.profileId}/0`]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/occupation/${this.profileId}/${event.record.occupationInfoId}`]);
        }
    }


    public async getOccupationInfos() {
        debugger;

        this.occupationService.getOccupationInfo(this.profileId).subscribe(
            (success) => {
                this.occupationInfoList = success.data;
                this.occupationInfoList.forEach(x => {
                    x.contractTypeName = x.contractType.contractTypeName || "";
                    x.contractStartDate = this.commonService.getDateToSetForm(x.contractStartDate);
                    x.contractEndDate = this.commonService.getDateToSetForm(x.contractEndDate);
                })
        
                //for (let i = 0; i < success.data.length; i++) {
                //    success.data[i].contractStartDate = this.commonService.getDateToSetForm(success.data[i].contractStartDate);
                //    success.data[i].contractEndDate = this.commonService.getDateToSetForm(success.data[i].contractEndDate);

                //}  
                //console.log("get occupation: ", success);
                //this.occupationInfoList = success.data;

            },
            error => {
            });
    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Occupation List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Job Type', width: '5%', internalName: 'jobType', sort: true, type: ""},
            { headerName: 'JobHour', width: '5%', internalName: 'jobHour', sort: true, type: ""},
            { headerName: 'ContractType', width: '5%', internalName: 'contractTypeName', sort: true, type: "" },
            { headerName: 'Contract StartDate', width: '5%', internalName: 'contractStartDate', sort: true, type: "" },
            { headerName: 'Contract EndDate', width: '5%', internalName: 'contractEndDate', sort: true, type: "" },
            { headerName: 'CompanyName', width: '5%', internalName: 'companyName', sort: true, type: "" },
            { headerName: 'VATNo', width: '5%', internalName: 'vatNo', sort: true, type: "" },
            { headerName: 'Legal Company Address', width: '5%', internalName: 'legalCompanyAddress', sort: true, type: "" },
            { headerName: 'Office Address', width: '5%', internalName: 'officeAddress', sort: true, type: "" },
            { headerName: 'Branch Address', width: '5%', internalName: 'branchAddress', sort: true, type: "" },
            { headerName: 'Chamber Of CommerceRegNo', width: '5%', internalName: 'chamberOfCommerceRegNo', sort: true, type: "" },
            { headerName: 'Chamber OfCommerce CityName', width: '5%', internalName: 'chamberOfCommerceCityName', sort: true, type: "" },
            { headerName: 'REANo', width: '5%', internalName: 'reaNo', sort: true, type: "" },
            { headerName: 'ATECONo', width: '5%', internalName: 'atecoNo', sort: true, type: "" },
            { headerName: 'SCIANo', width: '5%', internalName: 'sciaNo', sort: true, type: "" },
            { headerName: 'SCIA CityName', width: '5%', internalName: 'sciaCityName', sort: true, type: "" },
            { headerName: 'IsShareHolder', width: '5%', internalName: 'isShareHolder', sort: true, type: "" },
            { headerName: 'Percentage of Share', width: '5%', internalName: 'percentageOfShare', sort: true, type: "" },
            { headerName: 'Notaio Info', width: '5%', internalName: 'notaioInfo', sort: true, type: "" },
            { headerName: 'Company Representative', width: '5%', internalName: 'companyRepresentative', sort: true, type: "" },
            { headerName: 'Details', width: '10%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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
        enabledRecordCreateBtn: true
    };

    public occupationInfoList = [
        
    ];

}
