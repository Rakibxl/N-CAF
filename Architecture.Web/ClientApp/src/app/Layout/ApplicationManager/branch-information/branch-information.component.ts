import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { BranchService } from '../../../Shared/Services/Users/branch.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
    selector: 'app-branch-information',
    templateUrl: './branch-information.component.html',
    styleUrls: ['./branch-information.component.css']
})
export class BranchInformationComponent implements OnInit {
    branchList: any[] = [];

    constructor(private router: Router, private branchService: BranchService, private alertService: AlertService, private commonService: CommonService) {

    }

    ngOnInit() {
        this.loadBranchList();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let branchId = event.record && event.record.branchId || 0;
        if (event.action == "new-record") {
            this.router.navigate([`/manager/branch-info/${branchId}`]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/manager/branch-info/${branchId}`]);
        }
    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Branch List',
        tableRowIDInternalName: "branchId",
        tableColDef: [
            { headerName: 'Branch Id', width: '6%', internalName: 'branchId', sort: true, type: "" },
            { headerName: 'Address', width: '15%', internalName: 'address', sort: true, type: "" },
            { headerName: 'City', width: '15%', internalName: 'city', sort: true, type: "" },
            { headerName: 'Contact Person', width: '10%', internalName: 'contactPerson', sort: false, type: "" },
            { headerName: 'Contact Number', width: '10%', internalName: 'contactNumber', sort: true, type: "" },
            { headerName: 'AgreementStart', width: '10%', internalName: 'agreementStart', sort: true, type: "" },
            { headerName: 'Number Of User', width: '10%', internalName: 'numberOfUser', sort: true, type: "" },
            { headerName: 'Is Locked', width: '10%', internalName: 'isLocked', sort: true, type: "" },
            { headerName: 'Note', width: '20%', internalName: 'note', sort: true, type: "" },
            { headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 15,
        enabledPagination: true,
        enabledAutoScrolled: false,
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
    }

    loadBranchList() {
        this.branchService.getBranchList().subscribe((res) => {
            this.alertService.fnLoading(false);
            if (res && res.data && res.data.length) {
                this.branchList = res.data;
                this.branchList.map(ex => {
                    // ex.full_name = ex.surName ? (ex.name + ' ' + ex.surName) : ex.name;
                    ex.agreementStart = this.commonService.getDateToSetForm(ex.agreementStart);
                    return ex;
                });
            }
        }, err => {
            this.alertService.tosterDanger(err);
        });
    }
}
