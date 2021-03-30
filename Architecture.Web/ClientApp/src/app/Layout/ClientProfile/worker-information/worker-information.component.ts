import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profWorkerInfo } from '../../../Shared/Entity/ClientProfile/profWorkerInfo';
import { WorkerInfoService } from '../../../Shared/Services/ClientProfile/worker-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-worker-information',
  templateUrl: './worker-information.component.html',
  styleUrls: ['./worker-information.component.css']
})
export class WorkerInformationComponent implements OnInit {
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private workerService: WorkerInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
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
        this.getWorkerInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            this.router.navigate([`/client-profile/worker-info/${this.profileId}/0`]);
            
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/worker-info/${this.profileId}/${event.record.workerInfoId}`]);
        }
    }

    public getWorkerInfos() {
        this.workerService.getWorkerInfo(this.profileId).subscribe(
            (success) => {
                this.workerInfoList = success.data;
                console.log("get worker: ", success);
                this.workerInfoList.forEach(x => {
                    x.workerTypeName = x.workerType.workerTypeName || "";
                    x.startDate = this.commonService.getDateToSetForm(x.startDate);
                    x.endDate = this.commonService.getDateToSetForm(x.endDate);
                })    
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Worker List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Worker Type', width: '20%', internalName: 'workerTypeName', sort: true, type: "" },
            { headerName: 'Name', width: '10%', internalName: 'name', sort: true, type: "" },
            { headerName: 'SurName', width: '10%', internalName: 'surName', sort: true, type: "" },
            { headerName: 'TaxCode', width: '10%', internalName: 'taxCode', sort: true, type: "" },
            { headerName: 'Contract Number', width: '10%', internalName: 'contractNumber', sort: true, type: "" },
            { headerName: 'Monthly Salary', width: '10%', internalName: 'monthlySalary', sort: true, type: "" },
            { headerName: 'Start Date', width: '10%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'endDate', sort: true, type: "" },
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

    public workerInfoList = [
       
    ];

}
