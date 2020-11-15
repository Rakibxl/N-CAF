import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { ProfFamilyInfo } from '../../../Shared/Entity/ClientProfile/profFamilyInfo';
import { FamilyInfoService } from '../../../Shared/Services/ClientProfile/family-info.service';

@Component({
  selector: 'app-family-information',
  templateUrl: './family-information.component.html',
  styleUrls: ['./family-information.component.css']
})
export class FamilyInformationComponent implements OnInit {
    public familyInfos: ProfFamilyInfo[] = [];
    constructor(private router: Router, private familyService: FamilyInfoService) { }
    
    ngOnInit() {
        this.getFamilyInfos();
    }



    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            this.router.navigate(['/client-profile/family-info/0']);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/family-info/0']);
        }
    }

    public getFamilyInfos() {
        let profileId = 1;
        this.familyService.getFamilyInfo(profileId).subscribe(
            (success) => {
                console.log("get family: ", success);
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
            { headerName: 'Relation Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Name', width: '10%', internalName: 'name', sort: true, type: "" },
            { headerName: 'SurName', width: '15%', internalName: 'surName', sort: true, type: "" },
            { headerName: 'TaxCode', width: '15%', internalName: 'taxCode', sort: true, type: "" },
            { headerName: 'Date Of Birth', width: '10%', internalName: 'dateOfBirth', sort: true, type: "" },
            { headerName: 'Place Of Birth', width: '10%', internalName: 'placeOfBirth', sort: true, type: "" },
            { headerName: 'Phone Number', width: '20%', internalName: 'phoneNumber', sort: true, type: "" },
            { headerName: 'Nationality', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Residence', width: '10%', internalName: 'ownershippercentage', sort: true, type: "" },
            //{ headerName: 'Tax Amount', width: '10%', internalName: 'taxamount', sort: true, type: "" },
            //{ headerName: 'Use-able Percentage', width: '10%', internalName: 'useablepercentage', sort: true, type: "" },
            //{ headerName: 'Any Restriction ByGovt', width: '10%', internalName: 'anyrestrictionbygovt', sort: true, type: "" },
            //{ headerName: 'City Name', width: '10%', internalName: 'cityname', sort: true, type: "" },
            //{ headerName: 'Note', width: '10%', internalName: 'note', sort: true, type: "" },
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

    public familyInfoList = [];

}
