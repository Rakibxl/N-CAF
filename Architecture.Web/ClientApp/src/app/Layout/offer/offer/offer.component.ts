import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { OccupationInfoService } from '../../../Shared/Services/ClientProfile/occupation-info.service';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { JobInfoService } from '../../../Shared/Services/Users/job-info.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';


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
    public occupationInfoList: any[] = [];
    public ptableSettings: IPTableSetting;

    constructor(private router: Router, private clientProfileService: ClientProfileService, private jobInfoService: JobInfoService,
        private commonService: CommonService, private occupationService: OccupationInfoService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.jobId = +this.route.snapshot.paramMap.get("jobId") || 0;
        console.log("profile Id: " + this.profileId, "job Id: ", this.jobId);
        this.fnGetJobById();
        this.loadBasicInfo();
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

    public fnGenerateOfferDocuments() {
        const url = this.router.serializeUrl(
            this.router.createUrlTree(['./generate-pdf/pdf/1/1/0'])
        );
        window.open(url, '_blank');
    }
}
