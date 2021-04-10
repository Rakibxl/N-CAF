import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';

@Component({
  selector: 'app-current-offer',
  templateUrl: './current-offer.component.html',
  styleUrls: ['./current-offer.component.css']
})
export class CurrentOfferComponent implements OnInit {
    public myOffers: JobInfo[] = [];
    public profileId: number = 0;
    constructor(private router: Router, private offerService: OfferInfoService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.offerService.getMyOfferByProfileId(this.profileId).subscribe((res: APIResponse) => {
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

    
    public fnPtableCellClick(event: any) {
        if (event.cellName=="apply") {
            this.router.navigate([`/show-offer/offer/${this.profileId}/${event.record.jobInfoId}/0`]);
        }
    }

    public fnCustomrTrigger(event) {
        if (event.action == "new-record") {
            this.router.navigate([`/client-profile/basic-info/0/${this.profileId}`]);
        }
    }

    
    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Your Offers',
        tableRowIDInternalName: "jobInfoId",
        tableColDef: [
            { headerName: 'Offer Title', width: '10%', internalName: 'title', sort: true, type: "" },
            { headerName: 'Description', width: '25%', internalName: 'description', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'endDate', sort: false, type: "" },
            { headerName: 'Video Link', width: '10%', internalName: 'videoLink', sort: true, type: "hyperlink" },
            { headerName: 'Document Link', width: '10%', internalName: 'documentLink', sort: true, type: "" },           
            { headerName: 'Details', width: '15%', internalName: 'apply', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

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
        enabledViewDetails: false,
        enabledRecordCreateBtn: true,
        newRecordButtonText: "Create New Profile"
    };

}
