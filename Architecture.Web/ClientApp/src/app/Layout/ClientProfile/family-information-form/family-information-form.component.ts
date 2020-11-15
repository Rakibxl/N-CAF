import { Component, OnInit } from '@angular/core';
import { ProfFamilyInfo } from '../../../Shared/Entity/ClientProfile/profFamilyInfo';
import { FamilyInfoService } from '../../../Shared/Services/ClientProfile/family-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';

@Component({
  selector: 'app-family-information-form',
  templateUrl: './family-information-form.component.html',
  styleUrls: ['./family-information-form.component.css']
})
export class FamilyInformationFormComponent implements OnInit {
    public familyInfoForm = new ProfFamilyInfo();
    constructor(private familyInfoService: FamilyInfoService, private alertService: AlertService) { }

  ngOnInit() {}

    public onSubmit() {
        debugger;
        console.table(this.familyInfoForm);
        this.familyInfoForm.profileId = 1;

        //this.familyInfoService.getFamilyInfo(this.familyInfoForm.profileId).subscribe(
        //    (success:any) => {
        //        console.log("success");
        //    },
        //    (error: any) => {
        //        console.log("error", error);
        //    });

        this.familyInfoService.saveFamilyInfo(this.familyInfoForm).subscribe(
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
