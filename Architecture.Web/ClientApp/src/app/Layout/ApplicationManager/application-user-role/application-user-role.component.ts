import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { RoleService } from '../../../Shared/Services/Users/role.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { AuthService } from 'src/app/Shared/Services/Users/auth.service';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';
import { RolePermissions } from 'src/app/Shared/Constants/user-role-permission';

@Component({
    selector: 'app-application-user-role',
    templateUrl: './application-user-role.component.html',
    styleUrls: ['./application-user-role.component.css']
})
export class ApplicationUserRoleComponent implements OnInit {
    roleList: any[] = [];
    hideListView: boolean = true;

    constructor(private router: Router, private authService: AuthService,
        private roleService: RoleService, private alertService: AlertService,
        private commonService: CommonService) {
    }


    ngOnInit() {
        this.getRoles();

        if (this.commonService.hasPermission(RolePermissions.UserRoles.ListView)) {
            this.hideListView = false;
        }
        if (this.commonService.hasPermission(RolePermissions.UserRoles.Create)) {
            this.ptableSettings.enabledRecordCreateBtn = true;
        }
        if (this.commonService.hasPermission(RolePermissions.UserRoles.Edit)) {
            this.ptableSettings.enabledEditBtn = true;
        }
        if (this.commonService.hasPermission(RolePermissions.UserRoles.Delete)) {
            this.ptableSettings.enabledDeleteBtn = true;
        }
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = event.record && event.record.id || 0;
        if (event.action == "new-record") {
            this.router.navigate(['/manager/user-role/' + id]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/manager/user-role/' + id]);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'User Role List',
        tableRowIDInternalName: "roleId",
        tableColDef: [
            { headerName: 'Role Id', width: '30%', internalName: 'id', sort: true, type: "" },
            { headerName: 'Role Name', width: '25%', internalName: 'name', sort: true, type: "" },
            // { headerName: 'Role Type', width: '15%', internalName: 'roletype', sort: true, type: "" },
            { headerName: 'Status', width: '25%', internalName: 'status', sort: false, type: "" },
            { headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 20,
        enabledPagination: false,
        enabledAutoScrolled: true,
        // enabledEditDeleteBtn: true,
        // enabledEditDeleteBtn: true,
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
        // enabledRecordCreateBtn: true,
        // enabledTotal: true,
        //enabledCheckbox:true,
        enabledRadioBtn: false,
        tableHeaderVisibility: true,
        // tableFooterVisibility:false,
        pTableStyle: {
            tableOverflowY: true,
            overflowContentHeight: '460px'
        }
    }

    getRoles() {
        this.roleService.getRoles().subscribe((res) => {
            this.alertService.fnLoading(false);
            if (res && res.data && res.data.length) {
                this.roleList = res.data;
            }
        }, err => {
            this.alertService.tosterDanger(err);
        });
    }
}
