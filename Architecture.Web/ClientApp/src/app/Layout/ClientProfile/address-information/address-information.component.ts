import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-address-information',
  templateUrl: './address-information.component.html',
  styleUrls: ['./address-information.component.css']
})
export class AddressInformationComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate(['../client-profile/address-new', id]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/manager/user-info-new']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Address List',
        tableRowIDInternalName: "userId",
        tableColDef: [
            { headerName: 'User Id', width: '10%', internalName: 'userId', sort: true, type: "" },
            { headerName: 'User Name ', width: '10%', internalName: 'username', sort: true, type: "" },
            { headerName: 'User Type ', width: '15%', internalName: 'usertype', sort: true, type: "" },
            { headerName: 'Branch Location', width: '15%', internalName: 'branchlocation', sort: true, type: "" },
            { headerName: 'Contact Number', width: '10%', internalName: 'contactnumber', sort: true, type: "" },
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

    public employeeList = [
        { userId: "NC-120", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-121", username: "mustafiz@gmail.com", usertype: "Branch User", branchlocation: "Firenze", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-122", username: "zaman@gmail.com", usertype: "Operator User", branchlocation: "Rome", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-123", username: "rakibh@gmail.com", usertype: "Client User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "Yes", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-124", username: "pial@gmail.com", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-125", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-126", username: "palash@gmail.coml", usertype: "Client User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "Yes", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-127", username: "palash@gmail.com ", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-128", username: "palash@gmail.com", usertype: "Client User", branchlocation: "Firenze", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-129", username: "palash@gmail.com", usertype: "Operator User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-130", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "Yes", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-131", username: "palash@gmail.com", usertype: "Client User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-132", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-133", username: "palash@gmail.com", usertype: "Client User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-134", username: "palash@gmail.com", usertype: "Operator User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "Yes", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-135", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-136", username: "palash@gmail.com", usertype: "Client User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "Yes", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-137", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Rome", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-138", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Como", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-139", username: "palash@gmail.com", usertype: "Client User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "Yes", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-140", username: "palash@gmail.com", usertype: "Operator User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-151", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-152", username: "palash@gmail.com", usertype: "Client User", branchlocation: "Bergamo", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "Yes", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-153", username: "palash@gmail.com", usertype: "Branch User", branchlocation: "Venice", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-154", username: "palash@gmail.com", usertype: "Operator User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "InActive", managerName: "Rakibul Tanvi", details: "More.." },
        { userId: "NC-155", username: "palash@gmail.com", usertype: "Client User", branchlocation: "Milan", contactnumber: "3896883996", lastlogin: "10/4/2020", ipaddress: "151.30.143.116", islocked: "No", status: "Active", managerName: "Rakibul Tanvi", details: "More.." },
    ];

}
