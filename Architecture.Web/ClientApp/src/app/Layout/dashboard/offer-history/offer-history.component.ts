import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
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
    public profileId: number;
    constructor(private router: Router, private offerService: OfferInfoService, private route: ActivatedRoute, private alertService: AlertService) { }

    ngOnInit() {
        this.profileId = (+this.route.snapshot.paramMap.get("profId") || 0);
        this.offerService.getClientCompletedOffer(this.profileId).subscribe((res: APIResponse) => {
            console.log("Success", res);
            this.myOffers = res.data || [];

        }, error => {
            console.log("Error ", error);
        });
    }
    onClickGeneratePDF() {
        const url = this.router.serializeUrl(
            this.router.createUrlTree(['./generate-pdf'])
        );
        window.open(url, '_blank');
    }

    onClickOffer() {
        const url = this.router.serializeUrl(
            this.router.createUrlTree(['./show-offer/offer/1/1'])
        );
        window.open(url, '_blank');
    }

    public fnPtableCellClick(event: any) {
        if (event.cellName == "apply") {
            this.router.navigate([`/show-offer/offer/${event.record.jobInfoId}/0`]);
        } else if (event.cellName == "download-recipt") {
            this.alertService.titleTosterSuccess("Feature will be enable soon. Thanks for clicking.");
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
            { headerName: 'Details', width: '7%', internalName: 'download-recipt', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye text-success", btnTitle: 'Receipt' },
            { headerName: 'Details', width: '7%', internalName: 'view-details', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye text-success", btnTitle: 'History' },

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
