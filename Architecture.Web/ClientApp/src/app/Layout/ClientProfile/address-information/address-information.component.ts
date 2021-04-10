import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profAddressInfo } from '../../../Shared/Entity/ClientProfile/profAddressInfo';
import { AddressInfoService } from '../../../Shared/Services/ClientProfile/address-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
    selector: 'app-address-information',
    templateUrl: './address-information.component.html',
    styleUrls: ['./address-information.component.css']
})
export class AddressInformationComponent implements OnInit {
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private addressService: AddressInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
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

        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getAddressInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            this.router.navigate([`/client-profile/address/${this.profileId}/0`]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/address/${this.profileId}/${event.record.addressInfoId}`]);
        }
    }

    public getAddressInfos() {
        this.addressService.getAddressInfo(this.profileId).subscribe(
            (success) => {                
                this.addressInfoList = success.data;

                console.log("get address: ", success);
                this.addressInfoList.forEach(x => {                  
                    x.startDate = this.commonService.getDateToSetForm(x.startDate);
                    x.endDate = this.commonService.getDateToSetForm(x.endDate);
                })    
            },
            error => {
            });
    }
  
    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Address List',
        tableRowIDInternalName: "addressinfoid",
        tableColDef: [

            { headerName: 'Address Type', width: '10%', internalName: 'addressType.addressTypeName', sort: true, type: "" },
            { headerName: 'Road Name ', width: '5%', internalName: 'roadName', sort: true, type: "" },
            { headerName: 'Road Number ', width: '5%', internalName: 'roadNo', sort: true, type: "", visible: false },
            { headerName: 'Building Number', width: '5%', internalName: 'buildingNo', sort: true, type: "" },
            { headerName: 'Floor Number', width: '5%', internalName: 'floorNo', sort: true, type: "" },
            { headerName: 'Appartment Number', width: '5%', internalName: 'appartmentNo', sort: true, type: "" },
            { headerName: 'Province', width: '5%', internalName: 'province', sort: true, type: "" },
            { headerName: 'City Name', width: '5%', internalName: 'cityName', sort: true, type: "" },
            { headerName: 'Postal Code', width: '5%', internalName: 'postalCode', sort: true, type: "" },
            { headerName: 'State', width: '5%', internalName: 'state', sort: true, type: "" },
            { headerName: 'Start Date', width: '5%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '5%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'Active', width: '5%', internalName: 'active', sort: true, type: "", visible: false},
            //{ headerName: 'Details', width: '5%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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

    public addressInfoList = [];

}
