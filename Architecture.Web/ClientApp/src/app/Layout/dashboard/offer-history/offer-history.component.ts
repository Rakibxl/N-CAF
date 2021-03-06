import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { OfferInfo } from '../../../Shared/Entity/Users/OfferInfo';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';

@Component({
  selector: 'app-offer-history',
  templateUrl: './offer-history.component.html',
  styleUrls: ['./offer-history.component.css']
})
export class OfferHistoryComponent implements OnInit {
    public myOffers: JobInfo[] = [];
    public selectedOffer: OfferInfo = new OfferInfo();
    public profileId: number;
    constructor(private router: Router, private offerService: OfferInfoService, private route: ActivatedRoute, private alertService: AlertService) { }

   public ngOnInit() {
        this.profileId = (+this.route.snapshot.paramMap.get("profId") || 0);
        this.offerService.getClientCompletedOffer(this.profileId).subscribe((res: APIResponse) => {
            console.log("Success", res);
            this.myOffers = res.data || [];

        }, error => {
            console.log("Error ", error);
        });
    }
   public onClickGeneratePDF() {
        const url = this.router.serializeUrl(
            this.router.createUrlTree(['./generate-pdf'])
        );
        window.open(url, '_blank');
    }

   public onClickOffer() {
        const url = this.router.serializeUrl(
            this.router.createUrlTree(['./show-offer/offer/1/1'])
        );
        window.open(url, '_blank');
    }

    public fnPtableCellClick(event: any) {
        if (event.cellName == "apply") {
            this.router.navigate([`/show-offer/offer/${event.record.jobInfoId}/0`]);
        } else if (event.cellName == "download-recipt") {
            let fileSrc = event.record.receiptSrc || null;
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
        } else if (event.cellName == "view-history") {
            this.selectedOffer = new OfferInfo();
            setTimeout(() => {
                this.selectedOffer = event.record;
            }, 700);
        }
    }

    public fnCustomrTrigger(event: any) {

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Offer History',
        tableRowIDInternalName: "jobInfoId",
        tableColDef: [
            { headerName: 'Code', width: '8%', internalName: 'code', sort: true, type: "" },
            { headerName: 'Offer Title', width: '10%', internalName: 'jobInfo.title', sort: true, type: "" },
            { headerName: 'Profile Name', width: '15%', internalName: 'profileName', sort: true, type: "" },
            { headerName: 'Operator Name', width: '15%', internalName: 'acceptedOperatorName', sort: true, type: "" },
            { headerName: 'Accepted Date', width: '10%', internalName: 'operatorAcceptedDate', sort: true, type: "Date", displayType: 'datetime' },
            { headerName: 'Completed Date', width: '10%', internalName: 'modified', sort: true, type: "Date", displayType: 'datetime' },
            { headerName: 'Status', width: '10%', internalName: 'offerStatus.offerStatusName', sort: false, type: "custom-badge" },
            { headerName: 'Details', width: '7%', internalName: 'download-recipt', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-download text-success", btnTitle: 'Receipt' },
            { headerName: 'Details', width: '7%', internalName: 'view-history', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye text-success", btnTitle: 'History' },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 5,
        enabledPagination: true,
        enabledEditDeleteBtn: false,
        enabledCellClick: true,
        enabledColumnFilter: false,
        enabledDataLength: true,
        enabledReflow: true,
        enabledViewDetails: false
    };

}
