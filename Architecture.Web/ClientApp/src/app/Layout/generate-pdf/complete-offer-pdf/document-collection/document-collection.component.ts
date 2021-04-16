import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../../Shared/Modules/p-table';
import { profDocumentInfo } from '../../../../Shared/Entity/ClientProfile/profDocumentInfo';
import { DocumentInfoService } from '../../../../Shared/Services/ClientProfile/document-info.service';
import { CommonService } from '../../../../Shared/Services/Common/common.service';
import { AlertService } from '../../../../Shared/Modules/alert/alert.service';
@Component({
  selector: 'app-document-collection',
  templateUrl: './document-collection.component.html',
  styleUrls: ['./document-collection.component.css']
})
export class DocumentCollectionComponent implements OnInit {
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private documentService: DocumentInfoService, private commonService: CommonService, private route: ActivatedRoute, private alertService: AlertService) { }
    private profileId: number;

    ngOnInit() {
        debugger;
        if (this.parentProfileId > 0) { // check the input value if not available then chekc the param
            this.profileId = this.parentProfileId;            
        } else {
            this.profileId = (+this.route.snapshot.paramMap.get("profileId") || 0);
        }


        this.getDocumentInfos();
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
        if (event.cellName == "download-file") {
            let fileSrc = event.record.documentSrc || null;
            if (fileSrc == null) {
                this.alertService.titleTosterWarning("File is not available. Please upload the file so that you can download for the next time.");
                return false;
            }
            let fileName = fileSrc.split("/")[fileSrc.split("/").length - 1];
            const link = document.createElement('a');
            link.setAttribute('target', '_blank');
            link.setAttribute('href', event.record.documentSrc);
            link.setAttribute('download', fileName);
            document.body.appendChild(link);
            link.click();
            link.remove();
        }
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
            { headerName: 'Files', width: '10%', internalName: 'download-file', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-download", btnTitle: "Download" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 15,
        enabledPagination: true,
        enabledEditDeleteBtn: false,
        enabledCellClick: true,
        enabledColumnFilter: false,
        enabledDataLength: false,
        enabledReflow: true,
        enabledExcelDownload: true,
        enabledRecordCreateBtn: false,
        enabledViewDetails: true

    };

    public documentInfoList = [

    ];

}
