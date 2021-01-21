import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { JobInfoService } from '../../../Shared/Services/Users/job-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { JobSectionLink } from '../../../Shared/Entity/Users/JobSectionLink';

@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html',
  styleUrls: ['./job-form.component.css']
})
export class JobFormComponent implements OnInit {
    public jobInfoForm = new JobInfo();
    public selectedJobSectionLink: JobSectionLink[]=[]
    private jobInfoId: number;

    constructor(private dropdownService: DropdownService, private jobinfoService: JobInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute) { }
    public sectionName = [];
    async ngOnInit() {
        this.jobInfoId = +this.route.snapshot.paramMap.get("id") || 0;
        if (this.jobInfoId != 0) {
            this.getJob()
        }
        this.sectionName = await this.dropdownService.getSectionName();
        console.log("this.sectionName", this.sectionName);
    }

    //selectedSectionIds: number[] = [1, 2, 3];

    selectedSectionIds: number[] = [];

    public onSubmit() {
        debugger;

        this.jobInfoForm.jobSectionLink = [];
        this.selectedSectionIds.forEach(m => {
            if (this.selectedJobSectionLink.filter(x => x.jobSectionLinkId == m).length > 0) {
                this.jobInfoForm.jobSectionLink.push(this.selectedJobSectionLink.find(x => x.jobSectionLinkId == m))
            } else {
                let sectionLink = new JobSectionLink();
                sectionLink.jobSectionLinkId= 0;
                sectionLink.jobInfoId= this.jobInfoId;
                sectionLink.sectionNameId = m;
                this.jobInfoForm.jobSectionLink.push(sectionLink)
            }
        });
        console.log(this.jobInfoForm);
        this.jobinfoService.saveJobInfo(this.jobInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/job-info/job-list`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getJob() {
        this.jobinfoService.getJobById(this.jobInfoId).subscribe(
            (success: APIResponse) => {
                success.data.startDate = this.commonService.getDateToSetForm(success.data.startDate);
                success.data.endDate = this.commonService.getDateToSetForm(success.data.endDate);
                this.jobInfoForm = success.data
                this.selectedJobSectionLink = this.jobInfoForm.jobSectionLink || [];
                this.selectedSectionIds = this.selectedJobSectionLink.map(x=>x.sectionNameId);
                console.table("selectedSectionIds:" + this.selectedSectionIds);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });
    }

    public fnBackToList() {
        this.router.navigate([`/job-info/job-list`]);
        return false;
    }


}
