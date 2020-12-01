import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profIncomeInfo } from '../../../Shared/Entity/ClientProfile/profIncomeInfo';
import { IncomeInfoService } from '../../../Shared/Services/ClientProfile/income-info.service';

@Component({
  selector: 'app-income-information',
  templateUrl: './income-information.component.html',
  styleUrls: ['./income-information.component.css']
})
export class IncomeInformationComponent implements OnInit {

    constructor(private router: Router, private incomeService: IncomeInfoService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        debugger;
        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getIncomeInfos();
  }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;            
            this.router.navigate([`/client-profile/income-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/client-profile/income-info/${this.profileId}/${event.record.incomeInfoId}`]);
        }
    }

    public getIncomeInfos() {
        debugger;
        this.incomeService.getIncomeInfo(this.profileId).subscribe(
            (success) => {
                console.log("get income: ", success);
                this.incomeInfoList = success.data;
            },
            error => {
            });
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Income List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            //{ headerName: 'Income Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            //{ headerName: 'Income Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Yearly Income', width: '10%', internalName: 'yearlyIncome', sort: true, type: "" },
            { headerName: 'Montly Income', width: '15%', internalName: 'monthlyIncome', sort: true, type: "" },
            { headerName: 'Year', width: '15%', internalName: 'year', sort: true, type: "" },
            { headerName: 'Month', width: '10%', internalName: 'month', sort: true, type: "" },
            { headerName: 'Document', width: '10%', internalName: 'document', sort: true, type: "" },
            { headerName: 'Status', width: '20%', internalName: 'status', sort: true, type: "" },       
            { headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 15,
        enabledPagination: false,
        enabledAutoScrolled: true,
         //enabledEditDeleteBtn: true,
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

    public incomeInfoList = [];

}
