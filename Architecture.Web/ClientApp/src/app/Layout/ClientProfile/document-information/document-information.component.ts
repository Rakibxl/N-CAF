import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profDocumentInfo } from '../../../Shared/Entity/ClientProfile/profDocumentInfo';
import { DocumentInfoService } from '../../../Shared/Services/ClientProfile/document-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-document-information',
  templateUrl: './document-information.component.html',
  styleUrls: ['./document-information.component.css']
})
export class DocumentInformationComponent implements OnInit {

    constructor(private router: Router, private documentService: DocumentInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        debugger;
        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getDocumentInfos();
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/client-profile/document-info/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {           
            this.router.navigate([`/client-profile/document-info/${this.profileId}/${event.record.documentInfoId}`]);
        }
    }


    public getDocumentInfos() {
        debugger;
        this.documentService.getDocumentInfo(this.profileId).subscribe(
            (success) => {
                console.log("get document: ", success);
                for (let i = 0; i < success.data.length; i++) {
                    success.data[i].issuedDate = this.commonService.getDateToSetForm(success.data[i].issuedDate);
                    success.data[i].expiryDate = this.commonService.getDateToSetForm(success.data[i].expiryDate);
                }
                this.documentInfoList = success.data;
            },
            error => {
            });


    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Document List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Document Type', width: '10%', internalName: 'documentType', sort: true, type: "" },
            { headerName: 'Document Name', width: '10%', internalName: 'documentName', sort: true, type: "" },
            { headerName: 'Purpose Of Document', width: '15%', internalName: 'purposeOfDocument', sort: true, type: "" },
            { headerName: 'Issued By', width: '15%', internalName: 'issuedBy', sort: true, type: "" },
            { headerName: 'Issue Date', width: '10%', internalName: 'issuedDate', sort: true, type: "" },
            { headerName: 'Expiry Date', width: '10%', internalName: 'expiryDate', sort: true, type: "" },         
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
        enabledRecordCreateBtn: true
    };

    public documentInfoList = [
        
    ];

}
