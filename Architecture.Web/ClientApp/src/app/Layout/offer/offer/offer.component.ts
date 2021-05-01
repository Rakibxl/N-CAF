import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { OccupationInfoService } from '../../../Shared/Services/ClientProfile/occupation-info.service';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { JobInfoService } from '../../../Shared/Services/Users/job-info.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { OfferInfo } from '../../../Shared/Entity/Dashboard/Offer-Info';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';
import { AuthService } from '../../../Shared/Services/Users/auth.service';


@Component({
    selector: 'app-offer',
    templateUrl: './offer.component.html',
    styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {
    public basicInfo: any = {};
    public profileId: number = 1;
    public jobInfo: JobInfo = new JobInfo();
    public jobId: number = 0;
    public offerInfoId: number = 0;
    public occupationInfoList: any[] = [];
    public ptableSettings: IPTableSetting;
    public applicationUserType: number;

    constructor(private router: Router, private clientProfileService: ClientProfileService, private jobInfoService: JobInfoService, private offerInfoService: OfferInfoService,
        private commonService: CommonService, private route: ActivatedRoute, private alertService: AlertService, private authService: AuthService) { }

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.jobId = +this.route.snapshot.paramMap.get("jobId") || 0;
        this.offerInfoId = +this.route.snapshot.paramMap.get("offerId") || 0;
       
        console.log("profile Id: " + this.profileId, "job Id: ", this.jobId);
        this.fnGetJobById();
        this.loadBasicInfo();
    }

    public getPoints() {
        if (this.authService.applicationUserTypeId==2) {// branch user
            return this.jobInfo.branchRequiredAmount;
        } else {// client 
            return this.jobInfo.clientRequiredAmount;
        }
    }

    onEditBasicInfo() {
        this.router.navigate([`/client-profile/basic-info/${this.basicInfo.profileId}`]);
    }

    loadBasicInfo() {
        this.clientProfileService.getBasicInfo(this.profileId).subscribe(res => {
            if (res && res.data.profileId) {
                res.data.dateOfBirth = this.commonService.getFormatedDateToSave(res.data.dateOfBirth);
                res.data.taxCodeStartDate = this.commonService.getFormatedDateToSave(res.data.taxCodeStartDate);
                res.data.taxCodeEndDate = this.commonService.getFormatedDateToSave(res.data.taxCodeEndDate);
                res.data.expectedBabyBirthDate = this.commonService.getFormatedDateToSave(res.data.expectedBabyBirthDate);
                res.data.unEmployedCertificateIssuesDate = this.commonService.getFormatedDateToSave(res.data.unEmployedCertificateIssuesDate);
                this.basicInfo = res.data;
            }
        }, (error: any) => {
            console.log(error)
        });
    }



    public fnCheckSectionVisible(sectionName): boolean {
        let returnVal = false;
        if ((this.jobInfo.jobSectionLink || []).length > 0) {
            this.jobInfo.jobSectionLink.forEach((sec:any) => {
                if ((sec.sectionName.sectionDescription||"") == sectionName) {
                    returnVal = true;
                }

            });

        }
        return returnVal;
    }

    fnGetJobById() {
        this.jobInfoService.getJobById(this.jobId).subscribe((res: APIResponse) => {
            this.jobInfo = res.data;
            console.log("this.jobInfo::", this.jobInfo);
        },
            (error) => {
                console.log("erros: ", error);
            });
    }

    public fnSubmitOffer() {
        this.alertService.confirm(`Are you confirm, that you will submit this offer for the next level. <i>Need ${this.getPoints()} points to process this offer</i>. Before submitting review the documents again`,
            () => {
                let offerInfo = new OfferInfo();
                offerInfo.jobId = this.jobId;
                offerInfo.profileId = this.profileId;
                offerInfo.offerStatusId = 1;
                offerInfo.offerInfoId = this.offerInfoId;
                this.offerInfoService.submitOffer(offerInfo).subscribe((res) => {
                    console.log("Response:: ", res);
                    this.alertService.tosterSuccess("Successfully your offer submitted.");
                    this.router.navigate([`/dashboard/common/${this.profileId}`]);
                },
                    (error) => {
                        console.log("Error: ", error);
                    });
            },

           () => { }        );
        //const url = this.router.serializeUrl(
        //    this.router.createUrlTree(['./generate-pdf/pdf/1/1/0'])
        //);
        //window.open(url, '_blank');
    }

}
