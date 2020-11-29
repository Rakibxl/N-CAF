import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profAddressInfo } from '../../../Shared/Entity/ClientProfile/profAddressInfo';
import { AddressInfoService } from '../../../Shared/Services/ClientProfile/address-info.service';

@Component({
    selector: 'app-address-information',
    templateUrl: './address-information.component.html',
    styleUrls: ['./address-information.component.css']
})
export class AddressInformationComponent implements OnInit {

    constructor(private router: Router, private addressService: AddressInfoService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 2;
        debugger;
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
            debugger;
            this.router.navigate([`/client-profile/address/${this.profileId}/0`]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/address/${this.profileId}/${event.record.addressInfoId}`]);
        }
    }

    public getAddressInfos() {
        debugger;
        this.addressService.getAddressInfo(this.profileId).subscribe(
            (success) => {
                console.log("get address: ", success);
                this.addressInfoList = success.data;
            },
            error => {
            });


    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Address List',
        tableRowIDInternalName: "addressinfoid",
        tableColDef: [

            { headerName: 'Address Type', width: '10%', internalName: 'addressType', sort: true, type: "" },
            { headerName: 'Road Name ', width: '10%', internalName: 'roadName', sort: true, type: "" },
            { headerName: 'Road Number ', width: '15%', internalName: 'roadNo', sort: true, type: "" },
            { headerName: 'Building Number', width: '15%', internalName: 'buildingNo', sort: true, type: "" },
            { headerName: 'Floor Number', width: '10%', internalName: 'floorNo', sort: true, type: "" },
            { headerName: 'Appartment Number', width: '10%', internalName: 'appartmentNo', sort: true, type: "" },
            { headerName: 'Province', width: '20%', internalName: 'province', sort: true, type: "" },
            { headerName: 'City Name', width: '10%', internalName: 'cityName', sort: true, type: "" },
            { headerName: 'Postal Code', width: '10%', internalName: 'postalCode', sort: true, type: "" },
            { headerName: 'State', width: '10%', internalName: 'state', sort: true, type: "" },
            { headerName: 'Start Date', width: '10%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'Active', width: '10%', internalName: 'active', sort: true, type: "" },
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

    public addressInfoList = [];

}
