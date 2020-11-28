import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profEducationInfo } from '../../../Shared/Entity/ClientProfile/profEducationInfo';
import { EducationInfoService } from '../../../Shared/Services/ClientProfile/education-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';


@Component({
  selector: 'app-educational-information-form',
  templateUrl: './educational-information-form.component.html',
  styleUrls: ['./educational-information-form.component.css']
})
export class EducationalInformationFormComponent implements OnInit {
    public educationInfoForm = new profEducationInfo();

    constructor(private educationInfoService: EducationInfoService, private alertService: AlertService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private educationInfoId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.educationInfoId = +this.route.snapshot.paramMap.get("id") || 0;
        console.log("this.profileId:", this.profileId, "this.educationInfoId", this.educationInfoId);
  }

    public onSubmit() {
        console.table(this.educationInfoForm);
        this.educationInfoForm.profileId = 2;


        this.educationInfoService.saveEducationInfo(this.educationInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getEducation() {

        this.educationInfoService.getEducaitonById(this.profileId, this.educationInfoId).subscribe(
            (success: APIResponse) => {
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
