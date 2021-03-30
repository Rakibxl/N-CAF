import { Component, Input, OnInit } from '@angular/core';
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
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private documentService: DocumentInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;

    ngOnInit() {
        if (this.parentProfileId > 0) { // check the input value if not available then chekc the param
            this.profileId = this.parentProfileId;
            this.ptableSettings.enabledEditDeleteBtn = false;
            this.ptableSettings.enabledEditBtn = true;
            this.ptableSettings.enabledPdfDownload = false;
            this.ptableSettings.enabledExcelDownload = false;
            this.ptableSettings.enabledPrint = false;
            this.ptableSettings.enabledColumnSetting = false;
        } else {
            this.profileId = (+this.route.snapshot.paramMap.get("profId") || 0);
        } 


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
            ;
            this.router.navigate([`/client-profile/document-info/${this.profileId}/0`]);
            
        }
        else if (event.action == "edit-item") {           
            this.router.navigate([`/client-profile/document-info/${this.profileId}/${event.record.documentInfoId}`]);
        }
    }


    public getDocumentInfos() {
        this.documentService.getDocumentInfo(this.profileId).subscribe(
            (success) => {
                this.documentInfoList = success.data;

                this.documentInfoList.forEach(x => {
                    x.documentTypeName = x.documentType.documentName || "";
                    x.issuedDate = this.commonService.getDateToSetForm(x.issuedDate);
                    x.expiryDate = this.commonService.getDateToSetForm(x.expiryDate);

                })    

                console.log("get document: ", success);
              
            },
            error => {
            });


    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Document List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Document Type', width: '10%', internalName: 'documentTypeName', sort: true, type: "" },
            { headerName: 'Document Name', width: '10%', internalName: 'documentName', sort: true, type: "" },
            { headerName: 'Purpose Of Document', width: '15%', internalName: 'purposeOfDocument', sort: true, type: "" },
            { headerName: 'Issued By', width: '15%', internalName: 'issuedBy', sort: true, type: "" },
            { headerName: 'Issue Date', width: '10%', internalName: 'issuedDate', sort: true, type: "" },
            { headerName: 'Expiry Date', width: '10%', internalName: 'expiryDate', sort: true, type: "" },         
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

    public documentInfoList = [
        
    ];

}
