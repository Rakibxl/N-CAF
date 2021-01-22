import { Component, OnInit } from '@angular/core';
import { IPTableSetting } from '../../../Shared/Modules/p-table/p-table.component';
import { Router } from '@angular/router';
import { UserService } from '../../../Shared/Services/Users/user.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
    selector: 'app-application-user',
    templateUrl: './application-user.component.html',
    styleUrls: ['./application-user.component.css']
})
export class ApplicationUserComponent implements OnInit {
    employeeList: any[] = [];

    constructor(private router: Router, private userService: UserService, private alertService: AlertService) {
    }

    ngOnInit() {
        this.getUsers();
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
            { headerName: 'User Id', width: '20%', internalName: 'id', sort: true, type: "" },
            { headerName: 'Name ', width: '10%', internalName: 'name', sort: true, type: "" },
            { headerName: 'Email', width: '10%', internalName: 'email', sort: true, type: "" },
            { headerName: 'User Type ', width: '15%', internalName: 'appUserTypeId', sort: true, type: "" },
            { headerName: 'Branch Location', width: '15%', internalName: 'branchInfoId', sort: true, type: "" },
            { headerName: 'Contact Number', width: '10%', internalName: 'phoneNumber', sort: true, type: "" },
            { headerName: 'Last Login', width: '10%', internalName: 'lastlogin', sort: true, type: "" },
            { headerName: 'Ip Address', width: '10%', internalName: 'ipaddress', sort: true, type: "" },
            { headerName: 'IsLocked', width: '10%', internalName: 'islocked', sort: true, type: "" },
            { headerName: 'Status', width: '20%', internalName: 'status', sort: true, type: "" },
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

    getUsers() {
        this.userService.getUsers().subscribe((res) => {
            this.alertService.fnLoading(false);
            if (res && res.data && res.data.items.length) {
                this.employeeList = res.data.items;

                this.employeeList.map(ex => {
                    ex.name = ex.surName ? (ex.name + ' ' + ex.surName) : ex.name;
                    return ex;
                });
            }
        }, err => {
            this.alertService.tosterDanger(err);
        });
    }

    // public employeeList = [
    //     { userId: "NC-120", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
    //     { userId: "NC-155", username: "palash@gmail.com", usertype: "Client User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
    // ];
}
