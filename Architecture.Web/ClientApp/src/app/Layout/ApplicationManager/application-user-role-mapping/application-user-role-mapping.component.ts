import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table/p-table.component';

@Component({
  selector: 'app-application-user-role-mapping',
  templateUrl: './application-user-role-mapping.component.html',
  styleUrls: ['./application-user-role-mapping.component.css']
})
export class ApplicationUserRoleMappingComponent implements OnInit {

  constructor(private router : Router) { }

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
        tableName: 'Role Mapping List',
        tableRowIDInternalName: "rolemappingId",
        tableColDef: [
            { headerName: 'Role MappingId', width: '10%', internalName: 'rolemappingId', sort: true, type: "" },
            { headerName: 'User Name', width: '15%', internalName: 'username', sort: true, type: "" },
            { headerName: 'Role Name', width: '15%', internalName: 'rolename', sort: true, type: "" },
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
        { rolemappingId: "NC-120", username: "palash@yahoo.com", rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-121", username: "mustafiz@gmail.com", status: "Active", rolename: "Branch- Admin",  details: "More.." },
        { rolemappingId: "NC-122", username: "zaman@yahoo.com", rolename: "Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-123", username: "rakib@gmail.com", rolename: "Operator",  status: "Active", details: "More.." },
        { rolemappingId: "NC-124 ", username: "rakib@gmail.com", rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-125", username: "mustafiz@gmail.com",  rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-126", username: "zaman@yahoo.com",   rolename: "Operator User",  status: "Active", details: "More.." },
        { rolemappingId: "NC-127", username: "rakib@gmail.com",    rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-128", username: "rakib@gmail.com", rolename: "Operator User",  status: "Active", details: "More.." },
        { rolemappingId: "NC-129", username: "mustafiz@gmail.com",   rolename: "Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-130", username: "mustafiz@gmail.com",  rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-131", username: "mustafiz@gmail.com", rolename: "Operator User",  status: "Active", details: "More.." },
        { rolemappingId: "NC-132", username: "mustafiz@gmail.com", rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-133", username: "mustafiz@gmail.com", rolename: "Operator User",  status: "Active", details: "More.." },
        { rolemappingId: "NC-134", username: "rakib@gmail.com",   rolename: "Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-135", username: "rakib@gmail.com", rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-136", username: "rakib@gmail.com", rolename: "Operator User",  status: "Active", details: "More.." },
        { rolemappingId: "NC-137", username: "mustafiz@gmail.com",  rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-138", username: "mustafiz@gmail.com", rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-139", username: "mustafiz@gmail.com",   rolename: "Operator User", status: "Active", details: "More.." },
        { rolemappingId: "NC-140", username: "mustafiz@gmail.com",  rolename: "Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-151", username: "mustafiz@gmail.com",  rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-152", username: "zaman@yahoo.com", rolename: "Operator User",  status: "Active", details: "More.." },
        { rolemappingId: "NC-153", username: "zaman@yahoo.com", rolename: "Branch- Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-154", username: "zaman@yahoo.com",   rolename: "Admin",  status: "Active", details: "More.." },
        { rolemappingId: "NC-155", username: "zaman@yahoo.com", rolename: "Operator User",  status: "Active", details: "More.." },
    ];

}
