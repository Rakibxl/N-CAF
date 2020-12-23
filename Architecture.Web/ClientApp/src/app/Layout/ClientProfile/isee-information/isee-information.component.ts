import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profISEEInfo } from '../../../Shared/Entity/ClientProfile/profISEEInfo';
import { ISEEInfoService } from '../../../Shared/Services/ClientProfile/isee-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-isee-information',
  templateUrl: './isee-information.component.html',
  styleUrls: ['./isee-information.component.css']
})
export class IseeInformationComponent implements OnInit {

    constructor(private router: Router, private iseeService: ISEEInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        debugger;
        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
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
            this.router.navigate([`/client-profile/isee-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/isee-info/${this.profileId}/${event.record.iseeInfoId}`]);
        }
    }

    public getISEEInfos() {
        debugger;
        this.iseeService.getISEEInfo(this.profileId).subscribe(
            (success) => {
                this.iseeInfoList = success.data;
                this.iseeInfoList.forEach(x => {
                    x.iseeClassTypeName = x.iseeClassType.iseeClassTypeName || "";
                    x.submittedDate = this.commonService.getDateToSetForm(x.submittedDate);
                    x.deliveryDate = this.commonService.getDateToSetForm(x.deliveryDate);
                    x.expiryDate = this.commonService.getDateToSetForm(x.expiryDate);

                })    

                console.log("get isee: ", success);
           
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Isee List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Isee Class', width: '10%', internalName: 'iseeClassTypeName', sort: true, type: "" },
            { headerName: 'IseeValue', width: '5%', internalName: 'iseeValue', sort: true, type: "" },
            { headerName: 'Point', width: '5%', internalName: 'point', sort: true, type: "" },
            { headerName: 'IseeFamilyIncome', width: '10%', internalName: 'iseeFamilyIncome', sort: true, type: "" },
            { headerName: 'IspAmount', width: '7%', internalName: 'ispAmount', sort: true, type: "" },
            { headerName: 'ISE Amount', width: '7%', internalName: 'iseAmount', sort: true, type: "" },
            { headerName: 'ISR Amount', width: '7%', internalName: 'isrAmount', sort: true, type: "" },
            { headerName: 'IdnetificationNumber', width: '10%', internalName: 'identificationNumber', sort: true, type: "" },
            { headerName: 'Submitted Date', width: '7%', internalName: 'submittedDate', sort: true, type: "" },
            { headerName: 'Delivery Date', width: '7%', internalName: 'deliveryDate', sort: true, type: "" },
            { headerName: 'Expiry Date', width: '7%', internalName: 'expiryDate', sort: true, type: "" },
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

    public iseeInfoList = [ ];


}
