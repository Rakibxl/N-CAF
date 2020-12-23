import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profLegalInfo } from '../../../Shared/Entity/ClientProfile/profLegalInfo';
import { LegalInfoService } from '../../../Shared/Services/ClientProfile/legal-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-legal-information',
  templateUrl: './legal-information.component.html',
  styleUrls: ['./legal-information.component.css']
})
export class LegalInformationComponent implements OnInit {

    constructor(private router: Router, private legalService: LegalInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        debugger;
        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getLegalInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/client-profile/legal-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/legal-info/${this.profileId}/${event.record.legalInfoId}`]);
        }
    }

    public getLegalInfos() {
        debugger;
        this.legalService.getLegalInfo(this.profileId).subscribe(
            (success) => {
                this.legalInfoList = success.data;
                console.log("get legal: ", success);
                this.legalInfoList.forEach(x => {
                    x.countryDescription = x.countryName.countryDescription || "";
                    x.startDate = this.commonService.getDateToSetForm(x.startDate);
                    x.endDate = this.commonService.getDateToSetForm(x.endDate);

                    console.log("Occupation Data", success.data);
                })    
             
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Legal List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Country Name', width: '10%', internalName: 'countryDescription', sort: true, type: "" },
            { headerName: 'CityName', width: '10%', internalName: 'cityName', sort: true, type: "" },
            { headerName: 'Start Date', width: '10%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'IsAnyCase', width: '10%', internalName: 'isAnyCase', sort: true, type: "" },
            { headerName: 'Ref No', width: '10%', internalName: 'refNo', sort: true, type: "" },
            { headerName: 'Reason', width: '10%', internalName: 'reason', sort: true, type: "" },
            { headerName: 'Note', width: '10%', internalName: 'note', sort: true, type: "" },          
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
        enabledRecordCreateBtn: true,
        enabledViewDetails: true
       
    };

    public legalInfoList = [];

}
