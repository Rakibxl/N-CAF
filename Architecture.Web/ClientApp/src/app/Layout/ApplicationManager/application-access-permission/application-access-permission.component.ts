import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-application-access-permission',
  templateUrl: './application-access-permission.component.html',
  styleUrls: ['./application-access-permission.component.css']
})
export class ApplicationAccessPermissionComponent implements OnInit {

  constructor( private router : Router) { }

  ngOnInit() {
  }



    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        if (event.action == "new-record") {
            this.router.navigate(['/manager/user-info-new']);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/manager/user-info-new']);
        }
    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Access Request List',
        tableRowIDInternalName: "accessreqid",
        tableColDef: [
            { headerName: 'Access Request Id', width: '10%', internalName: 'accessreqid', sort: true, type: "" },
            { headerName: 'Request Type', width: '10%', internalName: 'requesttype', sort: true, type: "" },
            { headerName: 'Approved By', width: '10%', internalName: 'approvedby', sort: true, type: "" },
            { headerName: 'Approved Date', width: '10%', internalName: 'approveddate', sort: true, type: "" },
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
        { accessreqid: "NC-120", requesttype: "createuser", approvedby: "Branch User",  approveddate: "10/4/2020", details: "More.." },
        { accessreqid: "NC-121", requesttype: "createuser", approvedby: "Branch User",  approveddate: "10/4/2020", details: "More.." },
        { accessreqid: "NC-122", requesttype: "createuser", approvedby: "Operator User",   approveddate: "10/4/2020vi", details: "More.." },
        { accessreqid: "NC-123", requesttype: "createuser", approvedby: "Client User",   approveddate: "10/4/2020", details: "More.." },
        { accessreqid: "NC-124", requesttype: "createuser", approvedby: "Branch User",   approveddate: "10/4/2020", details: "More.." },
        { accessreqid: "NC-125", requesttype: "createuser", approvedby: "Branch User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-126", requesttype: "createuserl", approvedby: "Client User",  approveddate: "10/4/2020", details: "More.." },
        { accessreqid: "NC-127", requesttype: "createuser ", approvedby: "Branch User",  approveddate: "10/4/2020", details: "More.." },
        { accessreqid: "NC-128", requesttype: "createuser", approvedby: "Client User",   approveddate: "10/4/2020", details: "More.." },
        { accessreqid: "NC-129", requesttype: "createuser", approvedby: "Operator User",   approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-130", requesttype: "createuser", approvedby: "Branch User",   approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-131", requesttype: "createuser", approvedby: "Client User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-132", requesttype: "createuser", approvedby: "Branch User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-133", requesttype: "createuser", approvedby: "Client User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-134", requesttype: "createuser", approvedby: "Operator User",   approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-135", requesttype: "createuser", approvedby: "Branch User",   approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-136", requesttype: "createuser", approvedby: "Client User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-137", requesttype: "createuser", approvedby: "Branch User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-138", requesttype: "createuser", approvedby: "Branch User",   approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-139", requesttype: "createuser", approvedby: "Client User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-140", requesttype: "createuser", approvedby: "Operator User", approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-151", requesttype: "createuser", approvedby: "Branch User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-152", requesttype: "createuser", approvedby: "Client User",   approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-153", requesttype: "createuser", approvedby: "Branch User",   approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-154", requesttype: "createuser", approvedby: "Operator User",  approveddate: "10/4/2020",  details: "More.." },
        { accessreqid: "NC-155", requesttype: "createuser", approvedby: "Client User",  approveddate: "10/4/2020",  details: "More.." },
    ];
}
