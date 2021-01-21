import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table/p-table.component';
import { UserRoleService } from '../../../Shared/Services/Users/user-role.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';

@Component({
    selector: 'app-application-user-role-mapping',
    templateUrl: './application-user-role-mapping.component.html',
    styleUrls: ['./application-user-role-mapping.component.css']
})
export class ApplicationUserRoleMappingComponent implements OnInit {
    userRoleList: any[] = [];

    constructor(private router: Router, private userRoleService: UserRoleService, private alertService: AlertService) { }

    ngOnInit() {
        this.getUserRoles();
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
            { headerName: 'User Name', width: '15%', internalName: 'userName', sort: true, type: "" },
            { headerName: 'Role Name', width: '15%', internalName: 'roleName', sort: true, type: "" },
            { headerName: 'BranchId', width: '10%', internalName: 'branchId', sort: true, type: "" },
            { headerName: 'Status', width: '10%', internalName: 'status', sort: false, type: "" },
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
