import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OfferInfo } from '../../../Shared/Entity/Dashboard/Offer-Info';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';

@Component({
  selector: 'app-pending-job',
  templateUrl: './pending-job.component.html',
  styleUrls: ['./pending-job.component.css']
})
export class PendingJobComponent implements OnInit {
    public myOffers: OfferInfo[] = [];
    constructor(private router: Router, private offerService: OfferInfoService, private alertService: AlertService, private commonService: CommonService) { }

    ngOnInit() {
        this.fnGetPendingOffer();
        OfferInfoService.subjectToReloadComponent.subscribe((reloadComponentName: any) => {
            if (reloadComponentName == "reload-pending-component") {
                this.fnGetPendingOffer();
            }
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
        console.log("event", event);
        if (event.cellName == "apply") {
            this.router.navigate([`/show-offer/offer/${event.record.jobInfoId}/0`]);
        } else if (event.cellName == "revert-request") {
            this.alertService.confirm("Do you want to revert this job. It will be open for all operator.",
                async () => {
                    await this.fnRequestToRevertTheFile(event.record.offerInfoId);
                    await this.fnGetPendingOffer();
                },
                () => { }
            );
        } else if (event.cellName == "view-details") {
            //completed-offer-pdf/:profileId/:jobId/:offerId
            this.router.navigate([`/generate-pdf/completed-offer-pdf/${event.record.profileId}/${event.record.jobId}/${event.record.offerInfoId}`]);
        }
    }

    public fnCustomrTrigger(event: any) {

    }

    public async fnRequestToRevertTheFile(offerInfoId) {
        await (await this.offerService.operatorOfferRevertRequest(offerInfoId)).toPromise().then((res: APIResponse) => {
            this.alertService.tosterSuccess(res.data);
            OfferInfoService.subjectToReloadComponent.next("reload-new-offer-component");
        }, (error: any) => {
            console.log("Error ", error);
        });
    }

    public fnGetPendingOffer() {
        this.offerService.getOperatorProgressOffer().subscribe((res: APIResponse) => {
            this.myOffers = res.data || [];
        }, error => {
            console.log("Error ", error);
        });
    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Job on Progress',
        tableRowIDInternalName: "jobInfoId",
        tableColDef: [
            { headerName: 'Offer Title', width: '10%', internalName: 'jobInfo.title', sort: true, type: "" },
            { headerName: 'Profile Name', width: '15%', internalName: 'profileName', sort: true, type: "" },
            { headerName: 'Operator Name', width: '10%', internalName: 'acceptedOperatorName', sort: true, type: "" },
            { headerName: 'Accepted Date', width: '10%', internalName: 'operatorAcceptedDate', sort: true, type: "Date" },
            { headerName: 'Status', width: '10%', internalName: 'offerStatus.offerStatusName', sort: false, type: "custom-badge" },
            { headerName: 'Modified Date ', width: '10%', internalName: 'modified', sort: true, type: "Date" },
            { headerName: 'Details', width: '7%', internalName: 'view-history', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye text-success", btnTitle: 'History' },
            { headerName: 'Details', width: '7%', internalName: 'view-details', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye text-success", btnTitle: 'View' },
            { headerName: 'Details', width: '7%', internalName: 'revert-request', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-close text-danger", btnTitle: 'Revert' },
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
