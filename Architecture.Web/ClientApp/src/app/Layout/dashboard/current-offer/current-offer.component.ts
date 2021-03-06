import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { IAuthUser } from '../../../Shared/Entity/Users/auth';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';
import { AuthService } from '../../../Shared/Services/Users/auth.service';

@Component({
  selector: 'app-current-offer',
  templateUrl: './current-offer.component.html',
  styleUrls: ['./current-offer.component.css']
})
export class CurrentOfferComponent implements OnInit {
    public myOffers: JobInfo[] = [];
    public profileId: number = 0;
    public user: IAuthUser;
    constructor(private router: Router, private offerService: OfferInfoService, private route: ActivatedRoute, private authService: AuthService, private basicInfoService: ClientProfileService) { }

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        if (this.profileId==0) {
            this.authService.currentUser.subscribe(user => this.user = user);
            if (this.user.appUserTypeId === 4) {//client
                this.basicInfoService.getCurrentUserBasicInfo().subscribe((res) => {
                    let profileInfo = res.data;
                    this.profileId = res.data.profileId;
                    this.ptableSettings.tableName = `Your Offers (${profileInfo.name} ${profileInfo.surName})`;
                    this.ptableSettings.newRecordButtonText = this.profileId > 0 ? "View Profile" : "Create New Profile";
                });
            } 
        } else {
            this.basicInfoService.getBasicInfo(this.profileId).subscribe((res) => {
                let profileInfo = res.data;
                this.profileId = res.data.profileId;
                this.ptableSettings.tableName = `Your Offers (${profileInfo.name} ${profileInfo.surName})`;
                this.ptableSettings.newRecordButtonText = this.profileId > 0 ? "View Profile" : "Create New Profile";
            });
        }

        this.fnGetMyOffer();
       
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
            this.router.navigate([`/client-profile/basic-info/${this.profileId}`]);
        }
    }

    public fnGetMyOffer() {
        this.offerService.getMyOfferByProfileId(this.profileId).subscribe((res: APIResponse) => {
            this.myOffers = res.data || [];
        }, error => {
            console.log("Error ", error);
        });
    }   
    
    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Your Offers',
        tableRowIDInternalName: "jobInfoId",
        tableColDef: [
            { headerName: 'Offer Title', width: '10%', internalName: 'title', sort: true, type: "" },
            { headerName: 'Description', width: '25%', internalName: 'description', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'endDate', sort: false, type: "Date", displayType: "datetime" },
            { headerName: 'Video Link', width: '10%', internalName: 'videoLink', sort: true, type: "hyperlink" },
            { headerName: 'Document Link', width: '10%', internalName: 'documentLink', sort: true, type: "" },
            { headerName: 'Details', width: '15%', internalName: 'apply', sort: true, type: "custom-button", onClick: 'true', innerBtnIcon: "fa fa-copy", btnTitle:"Apply" }
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
        newRecordButtonText: this.profileId>0?"View Profile":"Create New Profile"
    };

}
