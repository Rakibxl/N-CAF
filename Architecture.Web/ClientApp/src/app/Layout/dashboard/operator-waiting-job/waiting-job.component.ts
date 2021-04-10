import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OfferInfo } from '../../../Shared/Entity/Dashboard/Offer-Info';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';

@Component({
  selector: 'app-waiting-job',
  templateUrl: './waiting-job.component.html',
  styleUrls: ['./waiting-job.component.css']
})
export class WaitingJobComponent implements OnInit {
    public myOffers: JobInfo[] = [];
    public waitingJobOffers: OfferInfo[] = [];
    constructor(private router: Router, private offerService: OfferInfoService) { }

    ngOnInit() {
        this.offerService.getOperatorPendingOffer().subscribe((res: APIResponse) => {
            console.log("oeprator pending job:", res);
            this.waitingJobOffers = res.data || [];
            this.waitingJobOffers.forEach(item => {
                item.jobTitle = item.jobInfo.title || ""
            })
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
        }
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
            { headerName: 'Created Date', width: '10%', internalName: 'created', sort: true, type: "" },
            { headerName: 'Modified Date ', width: '10%', internalName: 'modified', sort: true, type: "" },
            { headerName: 'Details', width: '7%', internalName: 'details-dashboard', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-check text-success", btnTitle: 'Accept' },

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

