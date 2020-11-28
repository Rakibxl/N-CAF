import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profInsuranceInfo } from '../../../Shared/Entity/ClientProfile/profInsuranceInfo';
import { InsuranceInfoService } from '../../../Shared/Services/ClientProfile/insurance-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
    selector: 'app-insurance-information-form',
    templateUrl: './insurance-information-form.component.html',
    styleUrls: ['./insurance-information-form.component.css']
})
export class InsuranceInformationFormComponent implements OnInit {
    public insuranceInfoForm = new profInsuranceInfo();

    constructor(private insuranceInfoService: InsuranceInfoService, private alertService: AlertService, private router: Router) { }

    ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.insuranceInfoForm);
        this.insuranceInfoForm.profileId = 2;


        this.insuranceInfoService.saveInsuranceInfo(this.insuranceInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/insurance-info']);
    }
}
