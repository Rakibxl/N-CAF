import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profOccupationInfo } from '../../../Shared/Entity/ClientProfile/profOccupationInfo';
import { OccupationInfoService } from '../../../Shared/Services/ClientProfile/occupation-info.service';

@Component({
  selector: 'app-occupation-history',
  templateUrl: './occupation-history.component.html',
  styleUrls: ['./occupation-history.component.css']
})
export class OccupationHistoryComponent implements OnInit {

    constructor(private router: Router, private occupationService: OccupationInfoService, private route: ActivatedRoute) { }
    private profileId: number;

    ngOnInit() {
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
            this.router.navigate(['/client-profile/occupation/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            //this.router.navigate(['/client-profile/occupation/0']);
            this.router.navigate([`/client-profile/occupation/${this.profileId}/${event.record.occupationInfoId}`]);
        }
    }


    public getOccupationInfos() {
        debugger;
        this.occupationService.getOccupationInfo(this.profileId).subscribe(
            (success) => {
                console.log("get occupation: ", success);
                this.occupationInfoList = success.data;
            },
            error => {
            });
    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Occupation List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Job Type', width: '20%', internalName: 'jobType', sort: true, type: "" },
            { headerName: 'JobHour', width: '10%', internalName: 'jobHour', sort: true, type: "" },
            { headerName: 'ContractType', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'Contract StartDate', width: '15%', internalName: 'contractStartDate', sort: true, type: "" },
            { headerName: 'Contract EndDate', width: '10%', internalName: 'contractEndDate', sort: true, type: "" },
            { headerName: 'CompanyName', width: '10%', internalName: 'companyName', sort: true, type: "" },
            { headerName: 'VATNo', width: '20%', internalName: 'vatNo', sort: true, type: "" },
            { headerName: 'Legal Company Address', width: '10%', internalName: 'legalCompanyAddress', sort: true, type: "" },
            { headerName: 'Office Address', width: '10%', internalName: 'officeAddress', sort: true, type: "" },
            { headerName: 'Branch Address', width: '10%', internalName: 'branchAddress', sort: true, type: "" },
            { headerName: 'Chamber Of CommerceRegNo', width: '10%', internalName: 'chamberOfCommerceRegNo', sort: true, type: "" },
            { headerName: 'Chamber OfCommerce CityName', width: '10%', internalName: 'chamberOfCommerceCityName', sort: true, type: "" },
            { headerName: 'REANo', width: '10%', internalName: 'reaNo', sort: true, type: "" },
            { headerName: 'ATECONo', width: '10%', internalName: 'atecoNo', sort: true, type: "" },
            { headerName: 'SCIANo', width: '10%', internalName: 'sciaNo', sort: true, type: "" },
            { headerName: 'SCIA CityName', width: '10%', internalName: 'sciaCityName', sort: true, type: "" },
            { headerName: 'IsShareHolder', width: '10%', internalName: 'isShareHolder', sort: true, type: "" },
            { headerName: 'Percentage of Share', width: '10%', internalName: 'percentageOfShare', sort: true, type: "" },
            { headerName: 'Notaio Info', width: '10%', internalName: 'notaioInfo', sort: true, type: "" },
            { headerName: 'Company Representative', width: '10%', internalName: 'companyRepresentative', sort: true, type: "" },
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

    public occupationInfoList = [
        
    ];

}
