import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-application-user-role',
  templateUrl: './application-user-role.component.html',
  styleUrls: ['./application-user-role.component.css']
})
export class ApplicationUserRoleComponent implements OnInit {

    constructor(private router: Router) {
    }


  ngOnInit() {
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        if (event.action == "new-record") {
            this.router.navigate(['/manager/user-role-new']);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/manager/user-role-new']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'User Role List',
        tableRowIDInternalName: "roleId",
        tableColDef: [
            { headerName: 'Role Id', width: '10%', internalName: 'roleId', sort: true, type: "" },
            { headerName: 'Role Name', width: '15%', internalName: 'rolename', sort: true, type: "" },
            { headerName: 'Role Type', width: '15%', internalName: 'roletype', sort: true, type: "" },
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

    public employeeList = [
        { roleId: "NC-120", rolename: "Branch- Admin", roletype: "Branch- Admin", status: "Active",  details: "More.." },
        { roleId: "NC-121", rolename: "Branch- Admin", roletype: "Admin", status: "Active", details: "More.." },
        { roleId: "NC-122", rolename: "Admin", roletype: "Operator", status: "Active", details: "More.." },
        { roleId: "NC-123", rolename: "Operator", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-124 ", rolename: "Branch- Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-125", rolename: "Branch- Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-126", rolename: "Operator User", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-127", rolename: "Branch- Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-128", rolename: "Operator User", roletype: "Admin", status: "Active", details: "More.." },
        { roleId: "NC-129", rolename: "Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-130", rolename: "Branch- Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-131", rolename: "Operator User", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-132", rolename: "Branch- Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-133", rolename: "Operator User", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-134", rolename: "Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-135", rolename: "Branch- Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-136", rolename: "Operator User", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-137", rolename: "Branch- Admin", roletype: "Operator", status: "Active", details: "More.." },
        { roleId: "NC-138", rolename: "Branch- Admin", roletype: "Como", status: "Active", details: "More.." },
        { roleId: "NC-139", rolename: "Operator User", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-140", rolename: "Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-151", rolename: "Branch- Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-152", rolename: "Operator User", roletype: "Bergamo", status: "Active", details: "More.." },
        { roleId: "NC-153", rolename: "Branch- Admin", roletype: "Venice", status: "Active", details: "More.." },
        { roleId: "NC-154", rolename: "Admin", roletype: "Branch- Admin", status: "Active", details: "More.." },
        { roleId: "NC-155", rolename: "Operator User", roletype: "Branch- Admin", status: "Active", details: "More.." },
    ];

}
