import { Component, OnInit } from '@angular/core';
import { profEducationInfo } from '../../../Shared/Entity/ClientProfile/profEducationInfo';
import { EducationInfoService } from '../../../Shared/Services/ClientProfile/education-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
  selector: 'app-educational-information-form',
  templateUrl: './educational-information-form.component.html',
  styleUrls: ['./educational-information-form.component.css']
})
export class EducationalInformationFormComponent implements OnInit {
    public educationInfoForm = new profEducationInfo();

    constructor(private educationInfoService: EducationInfoService, private alertService: AlertService) { }

  ngOnInit() {
  }

    public onSubmit() {
        debugger;
        console.table(this.educationInfoForm);
        this.educationInfoForm.profileId = 1;


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

    public fnBackToList() {

    }

}
