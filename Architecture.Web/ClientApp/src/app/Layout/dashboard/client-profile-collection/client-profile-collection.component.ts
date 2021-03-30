import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-client-profile-collection',
  templateUrl: './client-profile-collection.component.html',
  styleUrls: ['./client-profile-collection.component.css']
})
export class ClientProfileCollectionComponent implements OnInit {
    clientList: any[] = [];

    constructor(private router: Router, private clientProfileService: ClientProfileService, private alertService: AlertService, private commonService: CommonService) {

    }

    ngOnInit() {
        this.getClients();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
        let profileId = event.record && event.record.profileId || 0;
        if (event.cellName == 'details-dashboard') {
            this.router.navigate([`/dashboard/common/${profileId}`]);
        }
        this.clientProfileService.profileId = event.record && event.record.profileId || 0;
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let profileId = event.record && event.record.profileId || 0;
        if (event.action == "new-record") {
            this.router.navigate([`/client-profile/basic-info/${profileId}`]);
        } else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/basic-info/${profileId}`]);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Client List',
        tableRowIDInternalName: "profileId",
        tableColDef: [
            { headerName: 'Name', width: '12%', internalName: 'full_name', sort: true, type: "", onClick: 'true' },
            { headerName: 'Date Of Birth', width: '10%', internalName: 'dateOfBirth', sort: true, type: "", onClick: 'true' },
            { headerName: 'Phone Number', width: '10%', internalName: 'phoneNumber', sort: true, type: "", onClick: 'true' },
            { headerName: 'Email', width: '10%', internalName: 'email', sort: true, type: "", onClick: 'true' },
            { headerName: 'Selected City', width: '1%', internalName: 'selectedCity', sort: true, type: "", onClick: 'true', visible: false },
            { headerName: 'Zip Code', width: '15%', internalName: 'zipCode', sort: true, type: "", onClick: 'true', visible: false },
            { headerName: 'Yearly Income', width: '12%', internalName: 'yearlyIncome', sort: true, type: "", onClick: 'true', visible: false },
            { headerName: 'Details', width: '7%', internalName: 'details-dashboard', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye", btnTitle:'Profile' },
            { headerName: 'Details', width: '7%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy", btnTitle:'Test' },
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
    }

    getClients() {
        this.clientProfileService.getBasicInfoList().subscribe((res) => {
            this.alertService.fnLoading(false);
            if (res && res.data && res.data.length) {
                this.clientList = res.data;
                this.clientList.map(ex => {
                    ex.full_name = ex.surName ? (ex.name + ' ' + ex.surName) : ex.name;
                    ex.dateOfBirth = this.commonService.getDateToSetForm(ex.dateOfBirth);
                    return ex;
                });
            }
        }, err => {
            this.alertService.tosterDanger(err);
        });
    }
}

