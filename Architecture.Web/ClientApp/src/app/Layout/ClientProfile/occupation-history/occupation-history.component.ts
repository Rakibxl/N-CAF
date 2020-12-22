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
                    x.jobTypeName = x.jobType.jobTypeName || "";
                    x.contractStartDate = this.commonService.getDateToSetForm(x.contractStartDate);
                    x.contractEndDate = this.commonService.getDateToSetForm(x.contractEndDate);

                    console.log("Occupation Data", success.data);
                })    
            },
            error => {
            });
    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Occupation List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Job Type', width: '5%', internalName: 'jobTypeName', sort: true, type: ""},
            { headerName: 'Job Hour', width: '5%', internalName: 'jobHour', sort: true, type: ""},
            { headerName: 'ContractType', width: '7%', internalName: 'contractTypeName', sort: true, type: "" },
            { headerName: 'Contract StartDate', width: '5%', internalName: 'contractStartDate', sort: true, type: "" },
            { headerName: 'Contract EndDate', width: '5%', internalName: 'contractEndDate', sort: true, type: "" },
            { headerName: 'CompanyName', width: '10%', internalName: 'companyName', sort: true, type: "" },
            { headerName: 'VAT No', width: '7%', internalName: 'vatNo', sort: true, type: "" },
            { headerName: 'Office Address', width: '5%', internalName: 'officeAddress', sort: true, type: ""  },
            { headerName: 'Legal Company Address', width: '5%', internalName: 'legalCompanyAddress', sort: true, type: "", visible: false },
            { headerName: 'Branch Address', width: '5%', internalName: 'branchAddress', sort: true, type: "", visible: true  },
            { headerName: 'Chamber Of CommerceRegNo', width: '5%', internalName: 'chamberOfCommerceRegNo', sort: true, type: "", visible: false  },
            { headerName: 'Chamber OfCommerce CityName', width: '5%', internalName: 'chamberOfCommerceCityName', sort: true, type: "", visible: false  },
            { headerName: 'REANo', width: '5%', internalName: 'reaNo', sort: true, type: "", visible: false  },
            { headerName: 'ATECONo', width: '5%', internalName: 'atecoNo', sort: true, type: "", visible: false  },
            { headerName: 'SCIANo', width: '5%', internalName: 'sciaNo', sort: true, type: "", visible: false  },
            { headerName: 'SCIA CityName', width: '5%', internalName: 'sciaCityName', sort: true, type: "", visible: false  },
            { headerName: 'IsShareHolder', width: '5%', internalName: 'isShareHolder', sort: true, type: "", visible: false  },
            { headerName: 'Percentage of Share', width: '5%', internalName: 'percentageOfShare', sort: true, type: "", visible: false  },
            { headerName: 'Notaio Info', width: '5%', internalName: 'notaioInfo', sort: true, type: "", visible: false  },
            { headerName: 'Company Representative', width: '5%', internalName: 'companyRepresentative', sort: true, type: "", visible: false },
            { headerName: 'Details', width: '7%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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

    public occupationInfoList = [
        
    ];

}
