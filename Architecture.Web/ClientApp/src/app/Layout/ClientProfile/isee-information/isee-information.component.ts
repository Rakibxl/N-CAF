import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profISEEInfo } from '../../../Shared/Entity/ClientProfile/profISEEInfo';
import { ISEEInfoService } from '../../../Shared/Services/ClientProfile/isee-info.service';

@Component({
  selector: 'app-isee-information',
  templateUrl: './isee-information.component.html',
  styleUrls: ['./isee-information.component.css']
})
export class IseeInformationComponent implements OnInit {

    constructor(private router: Router, private iseeService: ISEEInfoService) { }

    ngOnInit() {
        this.getISEEInfos();
    }



    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate(['/client-profile/isee-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/isee-info/0']);
        }
    }

    public getISEEInfos() {
        debugger;
        let profileId = 2;
        this.iseeService.getISEEInfo(profileId).subscribe(
            (success) => {
                console.log("get isee: ", success);
                this.iseeInfoList = success.data;
            },
            error => {
            });

    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Isee List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Isee Class', width: '20%', internalName: 'iseeClassType', sort: true, type: "" },
            { headerName: 'IseeValue', width: '10%', internalName: 'iseeValue', sort: true, type: "" },
            { headerName: 'Point', width: '15%', internalName: 'point', sort: true, type: "" },
            { headerName: 'IseeFamilyIncome', width: '15%', internalName: 'iseeFamilyIncome', sort: true, type: "" },
            { headerName: 'IspAmount', width: '10%', internalName: 'ispAmount', sort: true, type: "" },
            { headerName: 'ISE Amount', width: '10%', internalName: 'iseAmount', sort: true, type: "" },
            { headerName: 'ISR Amount', width: '20%', internalName: 'isrAmount', sort: true, type: "" },
            { headerName: 'IdnetificationNumber', width: '10%', internalName: 'identificationNumber', sort: true, type: "" },
            { headerName: 'Submitted Date', width: '10%', internalName: 'submittedDate', sort: true, type: "" },
            { headerName: 'Delivery Date', width: '10%', internalName: 'deliveryDate', sort: true, type: "" },
            { headerName: 'Expiry Date', width: '10%', internalName: 'expiryDate', sort: true, type: "" },
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

    public iseeInfoList = [ ];


}
