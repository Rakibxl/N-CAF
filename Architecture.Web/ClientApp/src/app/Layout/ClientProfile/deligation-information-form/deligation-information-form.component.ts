import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profDelegationInfo } from '../../../Shared/Entity/ClientProfile/profDelegationInfo';
import { DelegationInfoService } from '../../../Shared/Services/ClientProfile/delegation-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';

@Component({
  selector: 'app-deligation-information-form',
  templateUrl: './deligation-information-form.component.html',
  styleUrls: ['./deligation-information-form.component.css']
})
export class DeligationInformationFormComponent implements OnInit {

    public delegationInfoForm = new profDelegationInfo();

    constructor(private delegationInfoService: DelegationInfoService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.delegationInfoForm);
        this.delegationInfoForm.profileId = 2;


        this.delegationInfoService.saveDelegationInfo(this.delegationInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/deligation-info']);
    }

}
