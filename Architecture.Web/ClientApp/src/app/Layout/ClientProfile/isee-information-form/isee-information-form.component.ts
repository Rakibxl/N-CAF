import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profISEEInfo } from '../../../Shared/Entity/ClientProfile/profISEEInfo';
import { ISEEInfoService } from '../../../Shared/Services/ClientProfile/isee-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';

@Component({
  selector: 'app-isee-information-form',
  templateUrl: './isee-information-form.component.html',
  styleUrls: ['./isee-information-form.component.css']
})
export class IseeInformationFormComponent implements OnInit {
    public iseeInfoForm = new profISEEInfo();

    constructor(private iseeInfoService: ISEEInfoService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.iseeInfoForm);
        this.iseeInfoForm.profileId = 2;


        this.iseeInfoService.saveISEEInfo(this.iseeInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/isee-info']);
    }

}
