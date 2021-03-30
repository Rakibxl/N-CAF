import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
    public profileId:number = 1;
    public jobInfo: JobInfo = new JobInfo();
  public occupationInfoList: any[] = [];
  public ptableSettings: IPTableSetting;

    constructor(private router: Router, private clientProfileService: ClientProfileService, private jobInfoService:JobInfoService,
    private commonService: CommonService, private occupationService: OccupationInfoService) { }

    ngOnInit() {
        this.fnGetJobById();
        this.loadBasicInfo();
  }


  onEditBasicInfo() {
    this.router.navigate([`/client-profile/basic-info/${this.basicInfo.profileId}`]);
  }

  loadBasicInfo() {
    this.clientProfileService.getCurrentUserBasicInfo().subscribe(res => {
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

  
  
  

    fnGetJobById() {
        this.jobInfoService.getJobById(1).subscribe((res: APIResponse) => {
            this.jobInfo = res.data;
        },
            (error) => {
                console.log("erros: ", error);
            });
    }

    public fnGenerateOfferDocuments() {
        const url = this.router.serializeUrl(
            this.router.createUrlTree(['./generate-pdf/pdf/1/1/1'])
        );
        window.open(url, '_blank');
    }
}
