import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profEducationInfo } from '../../../Shared/Entity/ClientProfile/profEducationInfo';
import { EducationInfoService } from '../../../Shared/Services/ClientProfile/education-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';


@Component({
  selector: 'app-educational-information-form',
  templateUrl: './educational-information-form.component.html',
  styleUrls: ['./educational-information-form.component.css']
})
export class EducationalInformationFormComponent implements OnInit {
    public educationInfoForm = new profEducationInfo();
    public degreeNameDropdown:any[] = [];

    constructor(private educationInfoService: EducationInfoService, private commonService: CommonService, private alertService: AlertService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }
    private profileId: number;
    private educationInfoId: number;
    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.educationInfoId = +this.route.snapshot.paramMap.get("id") || 0

        this.degreeNameDropdown = await this.dropdownService.getDegreeName() || [];


        console.log("this.profileId:", this.profileId, "this.educationInfoId", this.educationInfoId);
        if (this.profileId != 0 && this.educationInfoId != 0) {
            this.getEducation()
        }
  }

    public onSubmit() {
        console.table(this.educationInfoForm);
        this.educationInfoForm.profileId = this.profileId;


        this.educationInfoService.saveEducationInfo(this.educationInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/education/${this.profileId}`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getEducation() {
       
        this.educationInfoService.getEducationById(this.profileId, this.educationInfoId).subscribe(
            (success: APIResponse) => {
                success.data.startYear = this.commonService.getDateToSetForm(success.data.startYear);
                success.data.endYear = this.commonService.getDateToSetForm(success.data.endYear);
                this.educationInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });
        
    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/education/${this.profileId}`]);
        return false;
    }

}
