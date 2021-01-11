import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { JobInfo } from '../../../Shared/Entity/Users/JobInfo';
import { JobInfoService } from '../../../Shared/Services/Users/job-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html',
  styleUrls: ['./job-form.component.css']
})
export class JobFormComponent implements OnInit {
    public jobInfoForm = new JobInfo();
    private jobId: number;

    constructor(private dropdownService: DropdownService, private jobinfoService: JobInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute) { }
    public sectionName = [];
    async ngOnInit() {
        this.jobId = +this.route.snapshot.paramMap.get("id") || 0;
        if (this.jobId != 0) {
            this.getJob()
        }
        this.sectionName = await this.dropdownService.getSectionName();
        console.log("this.sectionName", this.sectionName);
    }

    //selectedSectionIds: number[] = [1, 2, 3];

    selectedSectionIds: number[] = [];
    selectedSectionIds2: string[] = [];

    public onSubmit() {
        debugger;

        this.jobInfoForm.sectionList = this.selectedSectionIds.toString();
        console.table(this.jobInfoForm);
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
        debugger;
        this.jobinfoService.getJobById(this.jobId).subscribe(
            (success: APIResponse) => {
                success.data.startDate = this.commonService.getDateToSetForm(success.data.startDate);
                success.data.endDate = this.commonService.getDateToSetForm(success.data.endDate);
                this.jobInfoForm = success.data

                //this.selectedSectionIds.push(success.data.sectionList.array());
                    
                //this.selectedSectionIds = success.data.sectionList; 
                this.selectedSectionIds = success.data.sectionList;

                    //this.selectedSectionIds = [1, 2, 3];
                console.table("table" + this.selectedSectionIds);

                console.log("test " + success.data.sectionList.split(','));

                this.selectedSectionIds2 = success.data.sectionList;

                console.log("test2 " + this.selectedSectionIds2);


                //this.selectedSectionIds = this.selectedSectionIds2.values;

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
