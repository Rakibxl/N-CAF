import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table/p-table.component';
import { UserRoleService } from '../../../Shared/Services/Users/user-role.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';
import { RolePermissions } from 'src/app/Shared/Constants/user-role-permission';

@Component({
    selector: 'app-application-user-role-mapping',
    templateUrl: './application-user-role-mapping.component.html',
    styleUrls: ['./application-user-role-mapping.component.css']
})
export class ApplicationUserRoleMappingComponent implements OnInit {
    userRoleList: any[] = [];
    hideListView: boolean = true;

    constructor(private router: Router, private userRoleService: UserRoleService,
        private alertService: AlertService, private commonService: CommonService) {

    }

    ngOnInit() {
        this.getUserRoles();

        if (this.commonService.hasPermission(RolePermissions.UserRoleMapping.ListView)) {
            this.hideListView = false;
        }
        if (this.commonService.hasPermission(RolePermissions.UserRoleMapping.Create)) {
            this.ptableSettings.enabledRecordCreateBtn = true;
        }
        if (this.commonService.hasPermission(RolePermissions.UserRoleMapping.Edit)) {
            this.ptableSettings.enabledEditBtn = true;
        }
        if (this.commonService.hasPermission(RolePermissions.UserRoleMapping.Delete)) {
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
            this.router.navigate(['/manager/user-role-mapping/' + id]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/manager/user-role-mapping/' + id]);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Role Mapping List',
        tableRowIDInternalName: "rolemappingId",
        tableColDef: [
            { headerName: 'User Name', width: '25%', internalName: 'userName', sort: true, type: "" },
            { headerName: 'Role Name', width: '25%', internalName: 'roleName', sort: true, type: "" },
            { headerName: 'Branch Location', width: '30%', internalName: 'branchLocation', sort: true, type: "" },
            // { headerName: 'Status', width: '10%', internalName: 'status', sort: false, type: "" },
            { headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 20,
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
        // enabledTotal: true,
        //enabledCheckbox:true,
        enabledRadioBtn: false,
        tableHeaderVisibility: true,
        // tableFooterVisibility:false,
        pTableStyle: {
            tableOverflowY: true,
            overflowContentHeight: '460px'
        }
    };

    getUserRoles() {
        this.userRoleService.getUserRoles().subscribe((res) => {
            this.alertService.fnLoading(false);
            if (res && res.data && res.data.length) {
                this.userRoleList = res.data;
            }
        }, err => {
            this.alertService.tosterDanger(err);
        });
    }
}
