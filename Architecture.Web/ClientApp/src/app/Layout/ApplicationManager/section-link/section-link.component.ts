import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { SectionLink } from '../../../Shared/Entity/Users/SectionLink';
import { SectionLinkService } from '../../../Shared/Services/Users/section-link.service';


@Component({
  selector: 'app-section-link',
  templateUrl: './section-link.component.html',
  styleUrls: ['./section-link.component.css']
})
export class SectionLinkComponent implements OnInit {

    constructor(private router: Router, private sectionLinkService: SectionLinkService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.getSectionLink();
    }



    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/manager/section-link/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate([`/manager/section-link/${event.record.sectionLinkId}`]);
        }
    }

    public getSectionLink() {
        debugger;
        this.sectionLinkService.getSectionLinkInfo().subscribe(
            (success) => {
                this.sectionLinkList = success.data;
                console.log("get section info: ", success);
                this.sectionLinkList.forEach(x => {
                    x.sectionName = x.sectionName.sectionDescription || "";
                })

            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Section Link List',
        tableRowIDInternalName: "bankinfoid",
        tableColDef: [
            { headerName: 'Title', width: '20%', internalName: 'title', sort: true, type: "" },
            { headerName: 'Section Name', width: '30%', internalName: 'sectionName', sort: true, type: "" },
            { headerName: 'Action Link', width: '30%', internalName: 'actionLink', sort: true, type: "" },
            { headerName: 'Remarks', width: '20%', internalName: 'remarks', sort: true, type: "" },
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

    public sectionLinkList = [

    ];

}
