import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profEducationInfo } from '../../../Shared/Entity/ClientProfile/profEducationInfo';
import { EducationInfoService } from '../../../Shared/Services/ClientProfile/education-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-educational-information',
  templateUrl: './educational-information.component.html',
  styleUrls: ['./educational-information.component.css']
})
export class EducationalInformationComponent implements OnInit {

    constructor(private router: Router, private educationService: EducationInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        debugger;
        if (this.profileId==0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getEducationInfos();
  }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/client-profile/education/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            console.log("event:", event);
            this.router.navigate([`/client-profile/education/${this.profileId}/${event.record.educationInfoId}`]);
        }
    }

    public getEducationInfos() {
        this.educationService.getEducationInfo(this.profileId).subscribe(
            (success) => {
                console.log("get education: ", success);
                for (let i = 0; i < success.data.length; i++) {
                    success.data[i].startYear = this.commonService.getDateToSetForm(success.data[i].startYear);
                    success.data[i].endYear = this.commonService.getDateToSetForm(success.data[i].endYear);
                }
                this.educationInfoList = success.data;
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Education List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Degree Type', width: '20%', internalName: 'degreeType', sort: true, type: "" },
            { headerName: 'Inistitution Name', width: '10%', internalName: 'institutionName', sort: true, type: "" },
            { headerName: 'Start Year', width: '15%', internalName: 'startYear', sort: true, type: "" },
            { headerName: 'End Year', width: '15%', internalName: 'endYear', sort: true, type: "" },
            { headerName: 'University Address', width: '10%', internalName: 'universityAddress', sort: true, type: "" },
            { headerName: 'Activities and societies', width: '10%', internalName: 'activitiesAndSocieties', sort: true, type: "" },
            { headerName: 'Result', width: '20%', internalName: 'result', sort: true, type: "" },            
            { headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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
        enabledRecordCreateBtn: true
    };

    public educationInfoList = [];

}
