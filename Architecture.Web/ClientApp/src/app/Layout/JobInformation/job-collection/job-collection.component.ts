import { Component, OnInit } from '@angular/core';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { Router } from '@angular/router';

@Component({
  selector: 'app-job-collection',
  templateUrl: './job-collection.component.html',
  styleUrls: ['./job-collection.component.css']
})
export class JobCollectionComponent implements OnInit {

    constructor(private router: Router) { }

    ngOnInit() {
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        if (event.action == "new-record") {
            this.router.navigate(['/job/job-list/1']);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/job/job-list/1']);
        }
    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Job List',
        tableRowIDInternalName: "employeeId",
        tableColDef: [
            { headerName: 'Employee Id', width: '10%', internalName: 'employeeId', sort: true, type: "" },
            { headerName: 'Employee Name ', width: '10%', internalName: 'employeeName', sort: true, type: "" },
            { headerName: 'Joinging Date ', width: '15%', internalName: 'joiningDate', sort: true, type: "" },
            { headerName: 'Employee Type', width: '15%', internalName: 'employeeType', sort: true, type: "" },
            { headerName: 'Working Project', width: '10%', internalName: 'workingProject', sort: false, type: "" },
            { headerName: 'Designation ', width: '10%', internalName: 'designation', sort: true, type: "" },
            { headerName: 'Team Name', width: '20%', internalName: 'teamName', sort: true, type: "" },
            { headerName: 'Manager Name', width: '10%', internalName: 'managerName', sort: true, type: "" },
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
        { employeeId: "BS-120", employeeName: "Palash Kanti Bachar", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-121", employeeName: "Md. Rabby Hasan", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-122", employeeName: "Md. Ashiquzzaman", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-123", employeeName: "Md. Nizam", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-124", employeeName: "Jisan", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-125", employeeName: "Kakon", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-126", employeeName: "Ahsanul Haq Shohel", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-127", employeeName: "Mr Kamal ", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-128", employeeName: "Mr Shohel", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-129", employeeName: "Mr Haq Shohel", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-130", employeeName: "Mr Haq", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-131", employeeName: "Mr Ahsanul", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-132", employeeName: "Mr Selim", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-133", employeeName: "Mr Ali", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-134", employeeName: "Mr Hasan", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-135", employeeName: "Mr Ali Akbor", joiningDate: "12/12/2018", employeeType: "Temporary", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-136", employeeName: "Mr Ali 1", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-137", employeeName: "Mr Ali 2", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-138", employeeName: "Mr Ali 3", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-139", employeeName: "Mr Ali 4", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-140", employeeName: "Mr Ali 5", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-151", employeeName: "Mr Ali 6", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-152", employeeName: "Mr Ali 7", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-153", employeeName: "Mr Ali 7", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-154", employeeName: "Mr Ali 7", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
        { employeeId: "BS-155", employeeName: "Mr Ali 7", joiningDate: "12/12/2018", employeeType: "Permanent", workingProject: "FM Application", designation: "Team Lead", teamName: "ASP.NET", managerName: "Rakibul Tanvi", details: "More.." },
    ];

}
