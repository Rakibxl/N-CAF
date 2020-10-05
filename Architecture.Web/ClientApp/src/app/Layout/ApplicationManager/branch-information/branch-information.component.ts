import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-branch-information',
  templateUrl: './branch-information.component.html',
  styleUrls: ['./branch-information.component.css']
})
export class BranchInformationComponent implements OnInit {

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
            this.router.navigate(['/manager/branch-info-new']);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/manager/branch-info-new']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Branch List',
        tableRowIDInternalName: "branchId",
        tableColDef: [
            { headerName: 'Branch Id', width: '10%', internalName: 'branchId', sort: true, type: "" },
            { headerName: 'Address', width: '15%', internalName: 'address', sort: true, type: "" },
            { headerName: 'City', width: '15%', internalName: 'city', sort: true, type: "" },
            { headerName: 'Contact Person', width: '10%', internalName: 'contactperson', sort: false, type: "" },
            { headerName: 'Contact Number', width: '10%', internalName: 'contactnumber', sort: true, type: "" },
            { headerName: 'AgreementStart', width: '20%', internalName: 'agreementstart', sort: true, type: "" },
            { headerName: 'Number Of User', width: '10%', internalName: 'numberofuser', sort: true, type: "" },
            { headerName: 'Is Locked', width: '10%', internalName: 'islocked', sort: true, type: "" },
            { headerName: 'Note', width: '10%', internalName: 'note', sort: true, type: "" },
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
        { branchId: "NC-120",  address: "Via Milano", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-121", address: "Via Milano", city: "Firenze", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok",  details: "More.." },
        { branchId: "NC-122", address: "Via Allesandro", city: "Rome", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "Yes", note: "ok", details: "More.." },
        { branchId: "NC-123", address: "Via Torino User", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-124 ", address: "Via Milano", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-125", address: "Via Milano", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-126", address: "Via Torino User", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-127", address: "Via Milano", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-128", address: "Via Torino User", city: "Firenze", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-129", address: "Via Allesandro", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "Yes", note: "ok", details: "More.." },
        { branchId: "NC-130", address: "Via Milano", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-131", address: "Via Torino User", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "Yes", note: "ok", details: "More.." },
        { branchId: "NC-132", address: "Via Milano", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-133", address: "Via Torino User", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-134", address: "Via Allesandro", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-135", address: "Via Milano", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-136", address: "Via Torino User", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "Yes", note: "ok", details: "More.." },
        { branchId: "NC-137", address: "Via Milano", city: "Rome", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-138", address: "Via Milano", city: "Como", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-139", address: "Via Torino User", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "In10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-140", address: "Via Allesandro", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-151", address: "Via Milano", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-152", address: "Via Torino User", city: "Bergamo", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "In10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-153", address: "Via Milano", city: "Venice", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-154", address: "Via Allesandro", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "In10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
        { branchId: "NC-155", address: "Via Torino User", city: "Milan", contactperson: "Admin", contactnumber: "3897664336", agreementstart: "10/4/2020", numberofuser: "1", islocked: "No", note: "ok", details: "More.." },
    ];
}
