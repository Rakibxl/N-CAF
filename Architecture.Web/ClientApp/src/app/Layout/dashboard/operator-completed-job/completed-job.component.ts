import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';

@Component({
  selector: 'app-completed-job',
  templateUrl: './completed-job.component.html',
  styleUrls: ['./completed-job.component.css']
})
export class CompletedJobComponent implements OnInit {
    public myOffers: JobInfo[] = [];
    constructor(private router: Router, private offerService: OfferInfoService) { }

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
        }
    }

    public fnCustomrTrigger(event: any) {

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Completed Job',
        tableRowIDInternalName: "jobInfoId",
        tableColDef: [
            { headerName: 'Offer Title', width: '10%', internalName: 'title', sort: true, type: "" },
            { headerName: 'Description', width: '25%', internalName: 'description', sort: true, type: "" },
            { headerName: 'Status', width: '10%', internalName: 'offerStatusName', sort: false, type: "" },
            { headerName: 'Created Date', width: '10%', internalName: 'created', sort: true, type: "" },
            { headerName: 'Modified Date ', width: '10%', internalName: 'modified', sort: true, type: "" },

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

