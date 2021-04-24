import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { OfferInfo } from '../../../Shared/Entity/Users/OfferInfo';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';

@Component({
  selector: 'app-completed-job',
  templateUrl: './completed-job.component.html',
  styleUrls: ['./completed-job.component.css']
})
export class CompletedJobComponent implements OnInit {
    public myOffers: OfferInfo[] = [];
    public selectedOffer: OfferInfo = new OfferInfo();
    constructor(private router: Router, private offerService: OfferInfoService, private alertService: AlertService) { }

    ngOnInit() {
        this.offerService.getOperatorCompletedOffer().subscribe((res: APIResponse) => {
            console.log("Success", res);
            this.myOffers = (res.data || []).filter(r=>r.offerStatusId==5)||[];

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
        } else if (event.cellName == "view-details") {
            this.router.navigate([`/generate-pdf/completed-offer-pdf/${event.record.profileId}/${event.record.jobId}/${event.record.offerInfoId}`]);
        } else if (event.cellName == "download-recipt") {
            this.alertService.titleTosterSuccess("Feature will be enable soon. Thanks for clicking.");
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
        tableName: 'Completed Job',
        tableRowIDInternalName: "jobInfoId",
        tableColDef: [    
            { headerName: 'Code', width: '8%', internalName: 'code', sort: true, type: "" },
            { headerName: 'Offer Title', width: '10%', internalName: 'jobInfo.title', sort: true, type: "" },
            { headerName: 'Profile Name', width: '15%', internalName: 'profileName', sort: true, type: "" },
            { headerName: 'Operator Name', width: '15%', internalName: 'acceptedOperatorName', sort: true, type: "" },
            { headerName: 'Accepted Date', width: '10%', internalName: 'operatorAcceptedDate', sort: true, type: "Date", displayType:'datetime' },
            { headerName: 'Status', width: '10%', internalName: 'offerStatus.offerStatusName', sort: false, type: "custom-badge" },
            { headerName: 'Completed Date ', width: '10%', internalName: 'modified', sort: true, type: "Date", displayType:'datetime' },
            { headerName: 'Details', width: '7%', internalName: 'download-recipt', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-download text-success", btnTitle: 'Receipt' },
            { headerName: 'Details', width: '7%', internalName: 'view-history', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye text-success", btnTitle: 'History' },
            { headerName: 'Details', width: '7%', internalName: 'view-details', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye text-success", btnTitle: 'View' },
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

