import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { JobInfoService } from '../../../Shared/Services/Users/job-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';


@Component({
    selector: 'app-job-list',
    templateUrl: './job-list.component.html',
    styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {

    constructor(private router: Router, private jobInfoService: JobInfoService, private commonService: CommonService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.getJobInfos();
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            this.router.navigate([`/job-info/job-info-new/0`]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/job-info/job-info-new/${event.record.jobInfoId}`]);
        }
    }


    public getJobInfos() {
        this.jobInfoService.getJobInfo().subscribe(
            (success) => {
                this.jobInfoList = success.data;
                console.log("job info: ", success);
                this.jobInfoList.forEach(x => {
                    x.jobDeliveryType = x.jobDeliveryType.jobDeliveryTypeName || "";
                    x.iseeClassTypeName = x.iseeClassType.iseeClassTypeName || "";
                    x.occupationTypeName = x.occupationType.occupationTypeName || "";
                    x.startDate = this.commonService.getDateToSetForm(x.startDate);
                    x.endDate = this.commonService.getDateToSetForm(x.endDate);
                });
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
            { headerName: 'Time Frame For Operator', width: '10%', internalName: 'videoLink', sort: true, type: "", visible:false },
            { headerName: 'Is Highlighted', width: '10%', internalName: 'isHighlighted', sort: true, type: "" },
            { headerName: 'Video Link', width: '10%', internalName: 'videoLink', sort: true, type: "" },
            { headerName: 'Document Link', width: '10%', internalName: 'documentLink', sort: true, type: "" },
            { headerName: 'Child Age Min', width: '10%', internalName: 'childAgeMin', sort: true, type: "", visible: false  },
            { headerName: 'Child Age Max', width: '10%', internalName: 'childAgeMax', sort: true, type: "", visible: false  },
            { headerName: 'ISEE Min', width: '10%', internalName: 'iseeMin', sort: true, type: "", visible: false },
            { headerName: 'ISEE Max', width: '10%', internalName: 'iseeMax', sort: true, type: "", visible: false },
            { headerName: 'ISEE Class', width: '10%', internalName: 'iseeClassTypeName', sort: true, type: "", visible: false  },
            { headerName: 'Is Pregnant', width: '10%', internalName: 'isPregnant', sort: true, type: "", visible: false },
            { headerName: 'Occupation Type', width: '10%', internalName: 'occupationTypeName', sort: true, type: "", visible: false },
            { headerName: 'Number Of Child', width: '10%', internalName: 'numberOfChild', sort: true, type: "", visible: false },
            { headerName: 'DaysToExpairJobContract', width: '10%', internalName: 'daysToExpairJobContract', sort: true, type: "", visible: false },
            { headerName: 'DaysToExpairResidence', width: '10%', internalName: 'daysToBeExpairedResidencePermit', sort: true, type: "", visible: false },
            { headerName: 'Is Eligible Unlimited Residence', width: '10%', internalName: 'isEligibleForUnlimitedResidencePermit', sort: true, type: "", visible: false },
            { headerName: 'DaysToExpairNationalID', width: '10%', internalName: 'daysToBeExpairedNationalId', sort: true, type: "", visible: false },
            { headerName: 'DaysToExpairPassport', width: '10%', internalName: 'daysToBeExpairedPassport', sort: true, type: "", visible: false },
            { headerName: 'IsEligibleCityzenShipApply', width: '10%', internalName: 'isEligibleForCityzenShipApply', sort: true, type: "", visible: false },
            { headerName: 'HasUnlimitedResidence', width: '10%', internalName: 'hasUnlimitedResidencePermit', sort: true, type: "", visible: false },
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
