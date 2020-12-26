import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { JobInfoService } from '../../../Shared/Services/Users/job-info.service';

@Component({
    selector: 'app-job-list',
    templateUrl: './job-list.component.html',
    styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {

    constructor(private router: Router, private jobInfoService: JobInfoService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.getQuestionInfos();
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    //public fnCustomrTrigger(event) {
    //    console.log("custom  click: ", event);
    //    if (event.action == "new-record") {
    //        this.router.navigate(['/job-info/job-info-new']);
    //    }
    //    else if (event.action == "edit-item") {
    //        this.router.navigate(['/job-info/job-info-new']);
    //    }
    //}

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/job-info/job-info-new/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/job-info/job-info-new/${event.record.jobInfoId}`]);
        }
    }


    public getQuestionInfos() {
        debugger;
        this.jobInfoService.getJobInfo().subscribe(
            (success) => {
                this.jobInfoList = success.data;
                console.log("job info: ", success);
                this.jobInfoList.forEach(x => {
                    x.jobDeliveryType = x.jobDeliveryType.jobDeliveryTypeName || "";
                    x.iseeClassType = x.ISEEClassType.iseeClassTypeName || "";
                    x.occupationTypeName = x.occupationType.OccupationTypeName || "";
                    x.sectionName = x.sectionName.sectionDescription || "";
                })

            },
            error => {
            });

    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Job List',
        tableRowIDInternalName: "employeeId",
        tableColDef: [
            { headerName: 'Job Title', width: '10%', internalName: 'title', sort: true, type: "" },
            { headerName: 'Description', width: '10%', internalName: 'description', sort: true, type: "" },
            { headerName: 'Start Date', width: '10%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'endDate', sort: false, type: "" },
            { headerName: 'Is Common', width: '10%', internalName: 'isCommon', sort: true, type: "" },
            { headerName: 'Job Delivery Type', width: '10%', internalName: 'jobDeliveryType', sort: true, type: "" },
            //{ headerName: 'Time Frame For Operator', width: '10%', internalName: 'videoLink', sort: true, type: "" },
            { headerName: 'Is Highlighted', width: '10%', internalName: 'isHighlighted', sort: true, type: "" },
            { headerName: 'Video Link', width: '10%', internalName: 'videoLink', sort: true, type: "" },
            { headerName: 'Document Link', width: '10%', internalName: 'documentLink', sort: true, type: "" },
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

    public jobInfoList = [];
   
}
