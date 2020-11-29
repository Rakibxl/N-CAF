import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profWorkerInfo } from '../../../Shared/Entity/ClientProfile/profWorkerInfo';
import { WorkerInfoService } from '../../../Shared/Services/ClientProfile/worker-info.service';

@Component({
  selector: 'app-worker-information',
  templateUrl: './worker-information.component.html',
  styleUrls: ['./worker-information.component.css']
})
export class WorkerInformationComponent implements OnInit {

    constructor(private router: Router, private workerService: WorkerInfoService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 2;
        debugger;
        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getWorkerInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/client-profile/worker-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/worker-info/${this.profileId}/${event.record.workerInfoId}`]);
        }
    }

    public getWorkerInfos() {
        debugger;
        this.workerService.getWorkerInfo(this.profileId).subscribe(
            (success) => {
                console.log("get worker: ", success);
                this.workerInfoList = success.data;
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Worker List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            //{ headerName: 'Worker Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            //{ headerName: 'Worker Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Name', width: '10%', internalName: 'name', sort: true, type: "" },
            { headerName: 'SurName', width: '15%', internalName: 'surName', sort: true, type: "" },
            { headerName: 'TaxCode', width: '15%', internalName: 'taxCode', sort: true, type: "" },
            { headerName: 'Contract Number', width: '10%', internalName: 'contractNumber', sort: true, type: "" },
            { headerName: 'Monthly Salary', width: '10%', internalName: 'monthlySalary', sort: true, type: "" },
            { headerName: 'Start Date', width: '20%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'endDate', sort: true, type: "" },
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

    public workerInfoList = [
       
    ];

}
