import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OfferInfo } from '../../../Shared/Entity/Dashboard/Offer-Info';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';
import { timer } from 'rxjs';


@Component({
  selector: 'app-waiting-job',
  templateUrl: './waiting-job.component.html',
  styleUrls: ['./waiting-job.component.css']
})
export class WaitingJobComponent implements OnInit {
    public myOffers: JobInfo[] = [];
    public waitingJobOffers: OfferInfo[] = [];
    constructor(private router: Router, private offerService: OfferInfoService, private alertService: AlertService, private commonService: CommonService) { }

    ngOnInit() {
        this.fnGetNewOffer();
        //user suject to reload the component of any changes of other component
        OfferInfoService.subjectToReloadComponent.subscribe((reloadComponentName: any) => {
            if (reloadComponentName == "reload-new-offer-component") {
                this.fnGetNewOffer();
            }
        });

      // timer to call the latest data
        timer(60000000, 60000000).subscribe(x => {
            this.fnGetNewOffer();
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
        if (event.cellName == "accept") {
            this.alertService.confirm("Do you want to proceed this file.", async () => {
                console.log("confirm request");
               await this.fnRequestToAcceptTheFile(event.record.offerInfoId||0);
            }, () => {// cancel request
                    console.log("cancel request");
            });
            return false;
        }
        if (event.cellName == "view-details") {
            this.router.navigate([`/show-offer/offer/${event.record.jobInfoId}/0`]);
        }
    }

    public async fnRequestToAcceptTheFile(offerInfoId) {
        await (await this.offerService.operatorOfferAcceptRequest(offerInfoId)).toPromise().then(async (res: APIResponse) => {
            await this.fnGetNewOffer();
            OfferInfoService.subjectToReloadComponent.next("reload-pending-component");
            this.alertService.tosterSuccess(res.data);
        }, error => {
            console.log("Error ", error);
        });
    }


    public fnGetNewOffer() {
        this.offerService.getOperatorPendingOffer().subscribe((res: APIResponse) => {
            console.log("oeprator pending job:", res);
            this.waitingJobOffers = res.data || [];           
        }, error => {
            console.log("Error ", error);
        });
    }

    public fnCustomrTrigger(event: any) {

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'New Job',
        tableRowIDInternalName: "jobInfoId",
        tableColDef: [
            { headerName: 'Offer Name', width: '10%', internalName: 'jobInfo.title', sort: true, type: "" },
            { headerName: 'Request By', width: '15%', internalName: 'profileName', sort: true, type: "" },
            { headerName: 'Status', width: '10%', internalName: 'offerStatus.offerStatusName', sort: false, type: "custom-badge" },
            { headerName: 'Created Date', width: '10%', internalName: 'created', sort: true, type: "Date" },
            { headerName: 'Validated By ', width: '10%', internalName: 'ValidatorName', sort: true, type: "" },
            //{ headerName: 'Modified Date ', width: '10%', internalName: 'modified', sort: true, type: "" },
            { headerName: 'Details', width: '7%', internalName: 'view-details', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-eye text-success", btnTitle: 'View' },
            { headerName: 'Details', width: '7%', internalName: 'accept', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-check text-success", btnTitle: 'Accept' },

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

