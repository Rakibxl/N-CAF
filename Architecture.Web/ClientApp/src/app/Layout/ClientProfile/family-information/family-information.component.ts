import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { ProfFamilyInfo } from '../../../Shared/Entity/ClientProfile/profFamilyInfo';
import { FamilyInfoService } from '../../../Shared/Services/ClientProfile/family-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-family-information',
  templateUrl: './family-information.component.html',
  styleUrls: ['./family-information.component.css']
})
export class FamilyInformationComponent implements OnInit {
    public familyInfos: ProfFamilyInfo[] = [];
    constructor(private router: Router, private familyService: FamilyInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        debugger;
        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getFamilyInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {            
            this.router.navigate([`/client-profile/family-info/${this.profileId}/0`]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/family-info/${this.profileId}/${event.record.familyInfoId}`]);
        }
    }

    public getFamilyInfos() {
        this.familyService.getFamilyInfo(this.profileId).subscribe(
            (success) => {
                console.log("get family: ", success);
                for (let i = 0; i < success.data.length; i++) {
                success.data[i].dateOfBirth = this.commonService.getDateToSetForm(success.data[i].dateOfBirth);
                success.data[i].applicationDate = this.commonService.getDateToSetForm(success.data[i].applicationDate);
                success.data[i].applicationPlacedDate = this.commonService.getDateToSetForm(success.data[i].applicationPlacedDate); 
                }
                this.familyInfoList = success.data;
            },
            error => {
            });


    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Family List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            //{ headerName: 'Relation Type', width: '10%', internalName: 'relationType', sort: true, type: "" },
            { headerName: 'Name', width: '10%', internalName: 'name', sort: true, type: "" },
            { headerName: 'SurName', width: '10%', internalName: 'surName', sort: true, type: "" },
            { headerName: 'TaxCode', width: '10%', internalName: 'taxCode', sort: true, type: "" },
            { headerName: 'Date Of Birth', width: '10%', internalName: 'dateOfBirth', sort: true, type: "" },
            { headerName: 'Place Of Birth', width: '10%', internalName: 'placeOfBirth', sort: true, type: "" },
            { headerName: 'Phone Number', width: '10%', internalName: 'phoneNumber', sort: true, type: "" },
            //{ headerName: 'Nationality', width: '10%', internalName: 'nationality', sort: true, type: "" },
            //{ headerName: 'Previous Nationality', width: '10%', internalName: 'previousNationality', sort: true, type: "" },
            //{ headerName: 'Residence Scope', width: '10%', internalName: 'residenceScope', sort: true, type: "" },
            //{ headerName: 'Occupation Type', width: '10%', internalName: 'occupationType', sort: true, type: "" },
            { headerName: 'Is Disabled', width: '10%', internalName: 'isDisabled', sort: true, type: "" },
            { headerName: 'Disabled Percentage', width: '10%', internalName: 'disabledPercentage', sort: true, type: "" },
            { headerName: 'Yearly Income', width: '10%', internalName: 'yearlyIncome', sort: true, type: "" },
            { headerName: 'Is Applied For Citizenship', width: '10%', internalName: 'isAppliedForCitizenship', sort: true, type: "" },            
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

    public familyInfoList = [];

}
