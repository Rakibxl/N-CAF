import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {

    constructor(private router: Router) { }

  ngOnInit() {
  }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        if (event.action == "new-record") {
            this.router.navigate(['/job-info/job-info-new']);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/job-info/job-info-new']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Job List',
        tableRowIDInternalName: "employeeId",
        tableColDef: [
            { headerName: 'Job Id', width: '10%', internalName: 'employeeId', sort: true, type: "" },
            { headerName: 'Job Title', width: '10%', internalName: 'employeeName', sort: true, type: "" },
            { headerName: 'Description', width: '15%', internalName: 'joiningDate', sort: true, type: "" },
            { headerName: 'Start Date', width: '15%', internalName: 'employeeType', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'employeeType', sort: false, type: "" },
            { headerName: 'Is Common', width: '10%', internalName: 'workingProject', sort: true, type: "" },
            { headerName: 'Job Delivery Type', width: '20%', internalName: 'designation', sort: true, type: "" },
            { headerName: 'Time Frame For Operator', width: '10%', internalName: 'teamName', sort: true, type: "" },
            { headerName: 'Is Highlighted', width: '10%', internalName: 'workingProject', sort: true, type: "" },
            { headerName: 'Video Link', width: '10%', internalName: 'managerName', sort: true, type: "" },
            { headerName: 'Document Link', width: '10%', internalName: 'managerName', sort: true, type: "" },
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
        { employeeId: "BS-120", employeeName: "Baby Bonus", joiningDate: "Water", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "National Caf", details: "More.." },
        { employeeId: "BS-121", employeeName: "Bonus Mamma", joiningDate: "Water", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-122", employeeName: "Carta Acquisto", joiningDate: "Baby Bonus", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Agenzia Entrate", details: "More.." },
        { employeeId: "BS-123", employeeName: "Electricity", joiningDate: "Baby Bonus", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Agenzia Entrate", details: "More.." },
        { employeeId: "BS-124", employeeName: "Gas", joiningDate: "Baby Bonus", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "National Caf", details: "More.." },
        { employeeId: "BS-125", employeeName: "Water", joiningDate: "Baby Bonus", employeeType: "20/07/2020", workingProject: "No", designation: "Urgent", teamName: "2", managerName: "Agenzia Entrate", details: "More.." },
        { employeeId: "BS-126", employeeName: "Assegno Maternità", joiningDate: "Assegno Maternità", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-127", employeeName: "Mr Kamal ", joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-128", employeeName: "Naspi",          joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-129", employeeName: "Baby Bonus",     joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-130", employeeName: "Water",          joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "No", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-131", employeeName: "Assegno Maternità", joiningDate: "Assegno Maternità", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-132", employeeName: "Water", joiningDate: "Assegno Maternità", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-133", employeeName: "Water", joiningDate: "Electricity", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-134", employeeName: "Assegno Maternità", joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "No", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-135", employeeName: "Water",              joiningDate: "Bonus Mamma", employeeType: "10/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-136", employeeName: "Electricity",        joiningDate: "Water", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-137", employeeName: "Water",              joiningDate: "Water", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-138", employeeName: "Assegno Maternità", joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-139", employeeName: "Electricity",        joiningDate: "Electricity", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-140", employeeName: "Assegno Maternità", joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-151", employeeName: "Water",             joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "No", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-152", employeeName: "Bonus Mamma",       joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "No", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-153", employeeName: "Assegno Maternità", joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-154", employeeName: "Baby Bonus",        joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "No", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
        { employeeId: "BS-155", employeeName: "Bonus Mamma",       joiningDate: "Bonus Mamma", employeeType: "20/07/2020", workingProject: "Yes", designation: "Urgent", teamName: "2", managerName: "Inps", details: "More.." },
    ];
}
