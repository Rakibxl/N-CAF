import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profMovementInfo } from '../../../Shared/Entity/ClientProfile/profMovementInfo';
import { MovementInfoService } from '../../../Shared/Services/ClientProfile/movement-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-movement-information',
  templateUrl: './movement-information.component.html',
  styleUrls: ['./movement-information.component.css']
})
export class MovementInformationComponent implements OnInit {
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private movementService: MovementInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
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
        this.getMovementInfos();
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/client-profile/movement-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/movement-info/${this.profileId}/${event.record.movementInfoId}`]);
        }
    }

    public getMovementInfos() {
        debugger;
        this.movementService.getMovementInfo(this.profileId).subscribe(
            (success) => {
                this.movementInfoList = success.data;
                console.log("get movement: ", success);
                this.movementInfoList.forEach(x => {
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
        tableName: 'Movement List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Country Name', width: '20%', internalName: 'countryDescription', sort: true, type: "" },
            { headerName: 'Start Date', width: '10%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '15%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'Purpose', width: '15%', internalName: 'purpose', sort: true, type: "" },
            { headerName: 'Status', width: '10%', internalName: 'status', sort: true, type: "" },            
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


    public movementInfoList = [
      
    ];

}
