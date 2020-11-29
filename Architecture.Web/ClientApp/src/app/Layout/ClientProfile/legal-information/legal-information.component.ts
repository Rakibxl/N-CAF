import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profLegalInfo } from '../../../Shared/Entity/ClientProfile/profLegalInfo';
import { LegalInfoService } from '../../../Shared/Services/ClientProfile/legal-info.service';

@Component({
  selector: 'app-legal-information',
  templateUrl: './legal-information.component.html',
  styleUrls: ['./legal-information.component.css']
})
export class LegalInformationComponent implements OnInit {

    constructor(private router: Router, private legalService: LegalInfoService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 2;
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
                console.log("get legal: ", success);
                this.legalInfoList = success.data;
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Legal List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            //{ headerName: 'Country Name', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'CityName', width: '10%', internalName: 'cityName', sort: true, type: "" },
            { headerName: 'Start Date', width: '15%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '15%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'IsAnyCase', width: '10%', internalName: 'isAnyCase', sort: true, type: "" },
            { headerName: 'Ref No', width: '10%', internalName: 'refNo', sort: true, type: "" },
            { headerName: 'Reason', width: '20%', internalName: 'reason', sort: true, type: "" },
            { headerName: 'Note', width: '10%', internalName: 'note', sort: true, type: "" },          
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

    public legalInfoList = [];

}
