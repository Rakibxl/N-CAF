import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profMovementInfo } from '../../../Shared/Entity/ClientProfile/profMovementInfo';
import { MovementInfoService } from '../../../Shared/Services/ClientProfile/movement-info.service';

@Component({
  selector: 'app-movement-information',
  templateUrl: './movement-information.component.html',
  styleUrls: ['./movement-information.component.css']
})
export class MovementInformationComponent implements OnInit {

    constructor(private router: Router, private movementService: MovementInfoService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 2;
        debugger;
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
                console.log("get movement: ", success);
                this.movementInfoList = success.data;
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Movement List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            //{ headerName: 'Country Name', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Start Date', width: '10%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '15%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'Purpose', width: '15%', internalName: 'purpose', sort: true, type: "" },
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


    public movementInfoList = [
      
    ];

}
