import { Component, Input, OnInit } from '@angular/core';
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
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private educationService: EducationInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
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
            this.router.navigate([`/client-profile/education/${this.profileId}/0`]);
        }
        else if (event.action == "edit-item") {
            console.log("event:", event);
            this.router.navigate([`/client-profile/education/${this.profileId}/${event.record.educationInfoId}`]);
        }
    }

    public getEducationInfos() {
        this.educationService.getEducationInfo(this.profileId).subscribe(
            (success) => {
                this.educationInfoList = success.data;
                console.log("get education: ", success);
                this.educationInfoList.forEach(x => {
                    x.degreeTypeName = x.degreeType.degreeTypeName || "";
                    x.startYear = this.commonService.getDateToSetForm(x.startYear);
                    x.endYear = this.commonService.getDateToSetForm(x.endYear);

                    console.log("Occupation Data", success.data);
                })    
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Education List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Degree Type', width: '20%', internalName: 'degreeTypeName', sort: true, type: "" },
            { headerName: 'Inistitution Name', width: '10%', internalName: 'institutionName', sort: true, type: "" },
            { headerName: 'Start Year', width: '15%', internalName: 'startYear', sort: true, type: "" },
            { headerName: 'End Year', width: '15%', internalName: 'endYear', sort: true, type: "" },
            { headerName: 'University Address', width: '10%', internalName: 'universityAddress', sort: true, type: "" },
            { headerName: 'Activities and societies', width: '10%', internalName: 'activitiesAndSocieties', sort: true, type: "" },
            { headerName: 'Result', width: '20%', internalName: 'result', sort: true, type: "" },            
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

    public educationInfoList = [];

}
