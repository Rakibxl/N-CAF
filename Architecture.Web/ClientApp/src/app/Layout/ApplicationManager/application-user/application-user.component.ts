import { Component, OnInit } from '@angular/core';
import { IPTableSetting } from '../../../Shared/Modules/p-table/p-table.component';
import { Router } from '@angular/router';
import { UserService } from '../../../Shared/Services/Users/user.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';
import { RolePermissions } from 'src/app/Shared/Constants/user-role-permission';


@Component({
    selector: 'app-application-user',
    templateUrl: './application-user.component.html',
    styleUrls: ['./application-user.component.css']
})
export class ApplicationUserComponent implements OnInit {
    employeeList: any[] = [];
    hideListView: boolean = true;

    constructor(private router: Router, private userService: UserService, private alertService: AlertService, private commonService: CommonService) {
    }

    ngOnInit() {
        this.getUsers();

        if (this.commonService.hasPermission(RolePermissions.Users.ListView)) {
            this.hideListView = false;
        }
        if (this.commonService.hasPermission(RolePermissions.Users.Create)) {
            this.ptableSettings.enabledRecordCreateBtn = true;
        }
        if (this.commonService.hasPermission(RolePermissions.Users.Edit)) {
            this.ptableSettings.enabledEditBtn = true;
        }
        if (this.commonService.hasPermission(RolePermissions.Users.Delete)) {
            this.ptableSettings.enabledDeleteBtn = true;
        }
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        let id = event.record && event.record.id || 0;
        if (event.action == "new-record") {
            this.router.navigate(['../manager/user-info/' + id]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['../manager/user-info/' + id]);
        }
    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Application User List',
        tableRowIDInternalName: "userId",
        tableColDef: [
            { headerName: 'User Id', width: '15%', internalName: 'id', sort: true, type: "" },
            { headerName: 'Name ', width: '10%', internalName: 'fullName', sort: true, type: "" },
            { headerName: 'Email', width: '10%', internalName: 'email', sort: true, type: "" },
            { headerName: 'User Type ', width: '10%', internalName: 'appUserType', sort: true, type: "" },
            { headerName: 'Branch Location', width: '10%', internalName: 'branchLocation', sort: true, type: "" },
            { headerName: 'Contact Number', width: '10%', internalName: 'phoneNumber', sort: true, type: "" },
            { headerName: 'Last Login', width: '10%', internalName: 'lastlogin', sort: true, type: "", visible: false },
            { headerName: 'Ip Address', width: '10%', internalName: 'ipaddress', sort: true, type: "", visible:false },
            { headerName: 'IsLocked', width: '8%', internalName: 'islocked', sort: true, type: "" },
            { headerName: 'Status', width: '8%', internalName: 'status', sort: true, type: "" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 20,
        enabledPagination: false,
        enabledAutoScrolled: true,
        // enabledEditDeleteBtn: true,
        // enabledEditDeleteBtn: true,
        // enabledDeleteBtn: true,
        enabledCellClick: true,
        enabledColumnFilter: true,
        enabledDataLength: true,
        enabledColumnResize: true,
        enabledReflow: true,
        enabledPdfDownload: true,
        enabledExcelDownload: true,
        enabledPrint: true,
        enabledColumnSetting: true,
        // enabledRecordCreateBtn: true,
        // enabledTotal: true,
        // enabledCheckbox:true,
        enabledRadioBtn: false,
        tableHeaderVisibility: true,
        // tableFooterVisibility:false,       
    };

    getUsers() {
        this.userService.getUsers().subscribe((res) => {
            this.alertService.fnLoading(false);
            if (res && res.data && res.data.length) {
                this.employeeList = res.data||[];                
            }
        }, err => {
            this.alertService.tosterDanger(err);
        });
    }
    
}
