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
                this.familyInfoList = success.data;
                console.log("get family: ", success);
                this.familyInfoList .forEach(x => {
                    x.relationTypeName = x.relationType.relationTypeName|| "";
                    //x.NationalityName = x.Nationality.NationalityName || "";
                    x.nationalityName = x.previousNationality.nationalityName || "";
                    x.residenceScopeName = x.residenceScope.residenceScopeName || "";
                    x.occupationTypeName = x.occupationType.occupationTypeName || "";
                    x.dateOfBirth = this.commonService.getDateToSetForm(x.dateOfBirth);
                    x.applicationDate = this.commonService.getDateToSetForm(x.applicationDate);
                    x.applicationPlacedDate = this.commonService.getDateToSetForm(x.applicationPlacedDate);
                })
            },
            error => {
            });
          
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Family List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Relation Type', width: '5%', internalName: 'relationTypeName', sort: true, type: "" },
            { headerName: 'Name', width: '5%', internalName: 'name', sort: true, type: "" },
            { headerName: 'SurName', width: '5%', internalName: 'surName', sort: true, type: "" },
            { headerName: 'TaxCode', width: '5%', internalName: 'taxCode', sort: true, type: "" },
            { headerName: 'Date Of Birth', width: '5%', internalName: 'dateOfBirth', sort: true, type: "" },
            { headerName: 'Place Of Birth', width: '5%', internalName: 'placeOfBirth', sort: true, type: "" },
            { headerName: 'Phone Number', width: '5%', internalName: 'phoneNumber', sort: true, type: "" },
            { headerName: 'Nationality', width: '5%', internalName: 'nationalityName', sort: true, type: "" },
            { headerName: 'Previous Nationality', width: '5%', internalName: 'nationalityName', sort: true, type: "" },
            { headerName: 'Residence Scope', width: '5%', internalName: 'residenceScopeName', sort: true, type: "" },
            { headerName: 'Occupation Type', width: '5%', internalName: 'occupationTypeName', sort: true, type: "" },
            { headerName: 'Is Disabled', width: '10%', internalName: 'isDisabled', sort: true, type: "", visible: false },
            { headerName: 'Disabled Percentage', width: '10%', internalName: 'disabledPercentage', sort: true, type: "", visible: false },
            { headerName: 'Yearly Income', width: '10%', internalName: 'yearlyIncome', sort: true, type: "", visible: false },
            { headerName: 'Is Applied For Citizenship', width: '10%', internalName: 'isAppliedForCitizenship', sort: true, type: "", visible: false },            
            { headerName: 'Details', width: '7%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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

    public familyInfoList = [];

}
