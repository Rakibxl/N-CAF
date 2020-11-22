import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profEducationInfo } from '../../../Shared/Entity/ClientProfile/profEducationInfo';
import { EducationInfoService } from '../../../Shared/Services/ClientProfile/education-info.service';


@Component({
  selector: 'app-educational-information',
  templateUrl: './educational-information.component.html',
  styleUrls: ['./educational-information.component.css']
})
export class EducationalInformationComponent implements OnInit {

    constructor(private router: Router, private educationService: EducationInfoService) { }

    ngOnInit() {
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
            this.router.navigate(['/client-profile/education/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/education/0']);
        }
    }

    public getEducationInfos() {
        let profileId = 2;
        this.educationService.getEducationInfo(profileId).subscribe(
            (success) => {
                console.log("get education: ", success);
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
            //{ headerName: 'Degree Name', width: '20%', internalName: 'assettype', sort: true, type: "" },
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

    public educationInfoList = [];

}
