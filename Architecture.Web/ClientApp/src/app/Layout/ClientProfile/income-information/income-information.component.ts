import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profIncomeInfo } from '../../../Shared/Entity/ClientProfile/profIncomeInfo';
import { IncomeInfoService } from '../../../Shared/Services/ClientProfile/income-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-income-information',
  templateUrl: './income-information.component.html',
  styleUrls: ['./income-information.component.css']
})
export class IncomeInformationComponent implements OnInit {

    constructor(private router: Router, private incomeService: IncomeInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
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
                this.incomeInfoList = success.data;
                this.incomeInfoList.forEach(x => {
                    x.incomeTypeName = x.incomeType.incomeTypeName || "";
                    x.year = this.commonService.getDateToSetForm(x.year);
                    x.month = this.commonService.getDateToSetForm(x.month);

                })    
                console.log("get income: ", success);
            },
            error => {
            });
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Income List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Income Type', width: '20%', internalName: 'incomeTypeName', sort: true, type: "" },
            { headerName: 'Yearly Income', width: '10%', internalName: 'yearlyIncome', sort: true, type: "" },
            { headerName: 'Monthly Income', width: '15%', internalName: 'monthlyIncome', sort: true, type: "" },
            { headerName: 'Year', width: '15%', internalName: 'year', sort: true, type: "" },
            { headerName: 'Month', width: '10%', internalName: 'month', sort: true, type: "" },
            { headerName: 'Document', width: '10%', internalName: 'document', sort: true, type: "" },
            { headerName: 'Status', width: '20%', internalName: 'status', sort: true, type: "" },       
            { headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 15,
        enabledPagination: true,
        enabledEditDeleteBtn: true,
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
        enabledViewDetails: true
    };

    public incomeInfoList = [];

}
