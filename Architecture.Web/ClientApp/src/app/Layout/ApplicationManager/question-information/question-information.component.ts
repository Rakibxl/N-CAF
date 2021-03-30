import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { QuestionInfo } from '../../../Shared/Entity/Users/QuestionInfo';
import { QuestionInfoService } from '../../../Shared/Services/Users/question-info.service';


@Component({
  selector: 'app-question-information',
  templateUrl: './question-information.component.html',
  styleUrls: ['./question-information.component.css']
})


export class QuestionInformationComponent implements OnInit {

    constructor(private router: Router, private questionService: QuestionInfoService, private route: ActivatedRoute) { }
    ngOnInit() {
        this.getQuestionInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            this.router.navigate([`/manager/question-info/0`]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/manager/question-info/${event.record.questionInfoId}`]);
        }
    }

    public getQuestionInfos() {
        this.questionService.getQuestionInfo().subscribe(
            (success) => {
                this.questionInfoList = success.data;
                this.questionInfoList.forEach(x => {
                    x.sectionName = x.sectionName.sectionDescription || "";
                })    

            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Question List',
        tableRowIDInternalName: "bankinfoid",
        tableColDef: [
            { headerName: 'Question Description', width: '30%', internalName: 'questionDescription', sort: true, type: "" },
            { headerName: 'Page to url', width: '15%', internalName: 'pageToUrl', sort: true, type: "" },
            { headerName: 'Section Name', width: '20%', internalName: 'sectionName', sort: true, type: "" },
            { headerName: 'Status', width: '15%', internalName: 'status', sort: true, type: "" },
            //{ headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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

    public questionInfoList = [

    ];

}


